﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter();
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        Heading GetByName(string name);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        List<Heading> Get(int id);
        List<Heading> CategoryNameWithTheMostTitles();


    }
}
