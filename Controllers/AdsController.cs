using Microsoft.AspNetCore.Mvc;
using MotorLine.Data;
using MotorLine.Models;
using MotorLine.ViewModel;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MotorLine.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdsDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdsController(AdsDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var ads = context.Ads.ToList();
            var adsVM = new List<AdsShowVM>();
            if (ads == null)
            {
                return NotFound();
            }

            foreach (var Ad in ads)
            {
                var ad_vm = new AdsShowVM()
                {
                    AdID = Ad.AdID,
                    Title = Ad.Title,
                    Description = Ad.Description,
                    Price = Ad.Price,
                    FuelType = Ad.FuelType,
                    Model = Ad.Model,
                    Type = Ad.Type,
                    Category = Ad.Category,
                    Color = Ad.Color,
                    Year = Ad.Year,
                    Motor = Ad.Motor,
                    Condition = Ad.Condition,
                    Photo1 = Ad.Photo1
                };
                adsVM.Add(ad_vm);
            }
            return View(adsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateOrEdit", new AdVM());
        }

        [HttpPost]
        public IActionResult Create(AdVM ad_vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", ad_vm);
            }

            var imageNames = SavePhotos(ad_vm);

            var ad = new Ad
            {
                Title = ad_vm.Title,
                Description = ad_vm.Description,
                Price = ad_vm.Price,
                FuelType = ad_vm.FuelType,
                Model = ad_vm.Model,
                Type = ad_vm.Type,
                Category = ad_vm.Category,
                Color = ad_vm.Color,
                Year = ad_vm.Year,
                Motor = ad_vm.Motor,
                Condition = ad_vm.Condition,
                Photo1 = imageNames[0],
                Photo2 = imageNames[1],
                Photo3 = imageNames[2],
                Photo4 = imageNames[3],
                Photo5 = imageNames[4]
            };

            try
            {
                context.Ads.Add(ad);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Title", "The title already exists");
                return View("CreateOrEdit", ad_vm);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ad = context.Ads.Find(id);
            if (ad == null)
            {
                return NotFound();
            }

            var ad_vm = new AdVM
            {
                AdID = ad.AdID,
                Title = ad.Title,
                Description = ad.Description,
                Price = ad.Price,
                FuelType = ad.FuelType,
                Model = ad.Model,
                Type = ad.Type,
                Category = ad.Category,
                Color = ad.Color,
                Year = ad.Year,
                Motor = ad.Motor,
                Condition = ad.Condition
                // No need to fill the photos in edit view model unless necessary
            };

            return View("CreateOrEdit", ad_vm);
        }

        [HttpPost]
        public IActionResult Edit(AdVM ad_vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", ad_vm);
            }
            var ad = context.Ads.Find(ad_vm.AdID);
            if (ad == null)
            {
                return NotFound();
            }

            var imageNames = SavePhotos(ad_vm);

            ad.Title = ad_vm.Title;
            ad.Description = ad_vm.Description;
            ad.Price = ad_vm.Price;
            ad.FuelType = ad_vm.FuelType;
            ad.Model = ad_vm.Model;
            ad.Type = ad_vm.Type;
            ad.Category = ad_vm.Category;
            ad.Color = ad_vm.Color;
            ad.Year = ad_vm.Year;
            ad.Motor = ad_vm.Motor;
            ad.Condition = ad_vm.Condition;
            ad.Photo1 = imageNames[0];
            ad.Photo2 = imageNames[1];
            ad.Photo3 = imageNames[2];
            ad.Photo4 = imageNames[3];
            ad.Photo5 = imageNames[4];

            try
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Title", "The title already exists");
                return View("CreateOrEdit", ad_vm);
            }
        }

        private string[] SavePhotos(AdVM ad_vm)
        {
            string[] imageNames = new string[5];

            // Save the first photo
            if (ad_vm.Photo1 != null)
            {
                string imageName1 = Path.GetFileName(ad_vm.Photo1.FileName);
                var path1 = Path.Combine($"{webHostEnvironment.WebRootPath}/imgs", imageName1);

                // Check if the file already exists and handle it
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1); // Optionally delete the existing file
                }

                using (var stream1 = new FileStream(path1, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    ad_vm.Photo1.CopyTo(stream1);
                }
                imageNames[0] = imageName1;
            }

            // Save additional photos
            for (int i = 1; i <= 4; i++)
            {
                IFormFile? additionalPhoto = ad_vm.GetType().GetProperty($"Photo{i + 1}")?.GetValue(ad_vm) as IFormFile;
                if (additionalPhoto != null)
                {
                    string imageName = Path.GetFileName(additionalPhoto.FileName);
                    var path = Path.Combine($"{webHostEnvironment.WebRootPath}/imgs", imageName);

                    // Check if the file already exists and handle it
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path); // Optionally delete the existing file
                    }

                    using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        additionalPhoto.CopyTo(stream);
                    }
                    imageNames[i] = imageName;
                }
            }

            return imageNames;
        }

        public IActionResult Details(int id)
            {
                var ad = context.Ads.Find(id);
                if (ad == null)
                {
                    return NotFound();
                }
                //map to view model
                return View();
            }

            public IActionResult Delete(int id)
            {
                var ad = context.Ads.Find(id);
                if (ad == null)
                {
                    return NotFound();
                }
                context.Ads.Remove(ad);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


            public IActionResult checkTitle(AdVM ad_vm)
            {
                var isExists = context.Ads.Any(ad => ad.Title == ad_vm.Title);
                return Json(!isExists);
            }
        }

    } 