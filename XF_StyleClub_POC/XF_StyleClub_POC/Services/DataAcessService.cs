using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Services.Interfaces;

namespace XF_StyleClub_POC.Services
{
    public class DataAcessService : IDataAcessService
    {
        public IEnumerable<ProductEntity> GetAllProducts(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService)
        {
            var allProducts = new List<ProductEntity>
            {
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 1",
                    Description = "Description 1",
                    ImageUrl = "http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 1",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 2",
                    Description = "Description 2",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIiE4UrM1WYxr5HQQyvouLkG4NGOeezW1U3XwD8PpPdoLf3_M",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 2",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/collections/accessories"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 3",
                    Description = "Description 3",
                    ImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 3",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 1",
                    Description = "Description 1",
                    ImageUrl = "http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 4",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/pages/boss-babes"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 2",
                    Description = "Description 2",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIiE4UrM1WYxr5HQQyvouLkG4NGOeezW1U3XwD8PpPdoLf3_M",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 5",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/pages/ambassador"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 3",
                    Description = "Description 3",
                    ImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 6",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/collections/outerwear"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 1",
                    Description = "Description 1",
                    ImageUrl = "http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 7",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/pages/press"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 2",
                    Description = "Description 2",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIiE4UrM1WYxr5HQQyvouLkG4NGOeezW1U3XwD8PpPdoLf3_M",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 8",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/collections/sweaters"
                },
                new ProductEntity(unityContainer, navigationService, loggingService, dialogService)
                {
                    Title = "Title 3",
                    Description = "Description 3",
                    ImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    Location = "Los Angels",
                    OwnerImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg",
                    OwnerName = "Owner Name 9",
                    CreatedDateTime = DateTime.Now,
                    VideoUrl = "http://vjs.zencdn.net/v/oceans.mp4",
                    WebsiteUrl = "http://thestyleclub.com/collections/tops"
                }
            };



            return allProducts;
        }
    }
}