using Nasa.Mars.RoverControl.Domain;
using Nasa.Mars.RoverControl.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Nasa.Mars.RoverControl
{
    /// <summary>
    /// Merhaba isterlerde net olarak belirtilmediği ve review ortamında kurulum gereksinimi oluşturmamak için uygulamayı konsol olarak yazdım.
    /// .net core 3.1 versiyonu ve VS 2019 Community kullandım. 
    /// Tercihe göre bir arayüz tasarımı yapılıp proje rest bir servisin arkasına konularbilirdi.
    /// Küçük bir geliştirme olduğu için herhangi bir DI kütüphanesi,ORM kütüphanesi,log kütüphanesi yada veritabanı kullanılmamıştır.
    /// Performans iyileştirmeleri veri miktarları küçük oladuğu için göz ardı edilmiştir.
    /// Unit testler için NUnit Kulllanılmıştır.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Rover> rovers = new List<Rover>();

                Console.WriteLine("Mars platosunun sınır değerlerini giriniz:");

                var plateauInput = Console.ReadLine();
                var plateauInputArray = plateauInput?.Split(' ');

                if (plateauInputArray == null && plateauInputArray.Length < 2)
                {
                    throw new Exception("Sınır değerleri uygun değil");
                }

                Console.WriteLine("Mars platosunun sınır değerlerini giriniz:");

                var plateau = new Plateau();

                if (Int32.TryParse(plateauInputArray[0], out int xLenght))
                {
                    plateau.xLenght = xLenght;
                }
                else
                {
                    throw new Exception("Sınır X değeri uygun değil");
                }

                if (Int32.TryParse(plateauInputArray[1], out int yLenght))
                {
                    plateau.yLenght = yLenght;
                }
                else
                {
                    throw new Exception("Sınır Y değeri uygun değil");
                }

                var roverOk = "e";
                while (roverOk.ToLower() == "e")
                {
                    Console.WriteLine("Mars aracı için konum giriniz:");

                    var roverPositionInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roverPositionInput))
                    {
                        throw new Exception("Mars aracı için konum hatalı");
                    }

                    Console.WriteLine("Mars aracı için komutları giriniz:");

                    var roverCommands = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roverCommands))
                    {
                        throw new Exception("Mars aracı için komut hatalı");
                    }

                    var roverPositionInputArray = roverPositionInput.Split(" ");

                    if (roverPositionInputArray == null && roverPositionInputArray.Length < 3)
                    {
                        throw new Exception("Konum değerleri uygun değil");
                    }

                    var position = new Position();

                    if (Int32.TryParse(roverPositionInputArray[0], out int x))
                    {
                        position.X = x;
                    }
                    else
                    {
                        throw new Exception("X değeri uygun değil");
                    }

                    if (Int32.TryParse(roverPositionInputArray[1], out int y))
                    {
                        position.Y = y;
                    }
                    else
                    {
                        throw new Exception("Y değeri uygun değil");
                    }

                    position.Direction = DirectionHelper.GetDirection(roverPositionInputArray[2].ToUpper().First());

                    rovers.Add(new Rover() { Commands = roverCommands, CurruntPosition = position });

                    Console.WriteLine("Yeni Mars aracı için giriş yapacak mısınız?(e/h):");

                    roverOk = Console.ReadLine();
                }

                var roverControl = new RoverMotion(plateau);

                foreach (var rover in rovers)
                {
                    foreach (var command in rover.Commands)
                    {
                        rover.CurruntPosition = roverControl.GetNextPosition(rover.CurruntPosition, command);
                    }

                    Console.WriteLine(rover.CurruntPosition.ToString());
                }


                Console.WriteLine("Çıkış için bir tuşa basınız");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }










}
