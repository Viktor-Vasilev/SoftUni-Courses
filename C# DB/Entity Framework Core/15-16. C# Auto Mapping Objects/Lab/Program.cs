
using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;



namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // .ReverseMap() се ползва когато искаме от вю модел да направиме клас, който после да вкараме в базата. 
            // Примерно когато потребителя е въвел нова песен от приложението, тя после за да се вкара в базата трябва да се обърне на клас, който го има в db контекста.

            //dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=MusicX;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models

          

            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Song, SongNameDTO>();
            });

            var mapper = config.CreateMapper();

            var db = new MusicXContext();

            Song song = db.Songs.Where(x => x.Id == 4)
              .FirstOrDefault();

            var songDTO = mapper.Map<SongNameDTO>(song);
            Console.WriteLine(songDTO);

          



        }

        class SongNameDTO
        {
            public string Name { get; set; }
        }
}
}
