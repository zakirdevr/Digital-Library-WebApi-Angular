using AutoMapper;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //CreateMap<From, To>()
            //CreateMap<Books, BookModel>();

            //CreateMap<Books, BookModel>() + Vice Versa
            CreateMap<Books, BookModel>().ReverseMap();

        }
    }
}
