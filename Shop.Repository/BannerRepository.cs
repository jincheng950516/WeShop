﻿using Shop.IRepository;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class BannerRepository : BaseRepository<Banner>,IBannerRepository//BaseService<Banner>, IBannerService
    {
        //public BannerService(IBaseRepository<Banner> ibaseRepository) : base(ibaseRepository)
        //{
        //}
    }
}
