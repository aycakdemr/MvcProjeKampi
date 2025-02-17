﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> Get(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }
        public List<Heading> CategoryNameWithTheMostTitles()
        {
            return _headingDal.List().GroupBy(x => x.CategoryId).Select(s => new Heading
            {
                CategoryId = s.LastOrDefault().CategoryId,
                Category = s.LastOrDefault().Category,
                Contents = s.LastOrDefault().Contents,
                HeadingDate = s.LastOrDefault().HeadingDate,
                HeadingId = s.LastOrDefault().HeadingId,
                HeadingName = s.LastOrDefault().HeadingName,
                writer = s.LastOrDefault().writer,
                WriterId = s.LastOrDefault().WriterId

            }).Take(1).OrderByDescending(o => o.CategoryId).ToList();
            
               

        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public Heading GetByName(string name)
        {
            return _headingDal.Get(x => x.HeadingName == name);
        }

        public void HeadingDelete(Heading heading)
        {
            
            _headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public List<HeadingChartDto> HeadingChart()
        {
            List<HeadingChartDto> chd = new List<HeadingChartDto>();
            foreach (var item in GetList())
            {
                chd.Add(new HeadingChartDto()
                {

                    HeadingName = item.HeadingName,
                    HeadingCount = GetList().Count
                });
            }
            return chd;
        }
    }
}
