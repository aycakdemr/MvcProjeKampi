﻿using EntityLayer.Concrete;
using EntityLayer.Dto;
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
        List<Heading> GetListByWriter(int id);

        List<HeadingChartDto> HeadingChart();
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        Heading GetByName(string name);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        List<Heading> Get(int id);
        List<Heading> CategoryNameWithTheMostTitles();


    }
}
