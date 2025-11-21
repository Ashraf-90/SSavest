using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<HeroBanner> HeroBanner { get; set; }
        public DbSet<MetaPages> MetaPages { get; set; }
        public DbSet<KeyWords> KeyWords { get; set; }
        public DbSet<Pixels> Pixels { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            //------------------------------------------------------------------------------------------
            //=============================== Meta Pages ===============================================

            builder.Entity<HeroBanner>().HasData(
            new HeroBanner
            {
                Id = 1,
                Text_One = "Your Trusted Partner in Comprehensive Security",
                Text_Two = "Dependable Cooling\nYou Can Trust — Anytime,\n Anywhere.",
                Text_Three = "From property protection to event security — we offer a wide range of security services tailored individually to your needs.",

                Image_One = "construction-workers-sunset.jpg",
                Image_Two = "inspectors-with-sketch.jpg",
                Image_Three = "working-with-blueprint.jpg"
            });



            //------------------------------------------------------------------------------------------
            //=============================== Meta Pages ===============================================

            builder.Entity<MetaPages>().HasData(
            new MetaPages
            {
                Id = 1,
                Page = "Home",
                EnPageTitle = "Home",
                ArPageTitle = "الرئيسية",
                EnMetaTitle = "Home",
                ArMetaTitle = "الرئيسية",
                EnMetaDescription = "SaVest is an innovative company committed to developing smart, " +
                "wearable solutions that enhance safety and comfort in extreme environments. " +
                "Born from a deep understanding of the challenges faced by outdoor workers, " +
                "SaVest designs practical, high-performance products tailored to real-world needs.",

                ArMetaDescription = "SaVest شركة مبتكرة ملتزمة بتطوير حلول ذكية قابلة للارتداء تُعزز السلامة والراحة في البيئات القاسية." +
                " انطلاقًا من فهمها العميق للتحديات التي يواجهها العاملون في الهواء الطلق، تُصمم SaVest منتجات عملية وعالية الأداء مُصممة خصيصًا لتلبية احتياجات العالم" +
                " الحقيقي."
            });

            //------------------------------------------------------------------------------------------
            //=============================== KeyWords ===============================================

            builder.Entity<KeyWords>().HasData(
            new KeyWords
            {
                Id = 1,
                EnKeyword = "wearable cooling mask",
                ArKeyword = "قناع تبريد قابل للارتداء"
            },
            new KeyWords
            {
                Id = 2,
                EnKeyword = "heat stress protection",
                ArKeyword = "حماية من الإجهاد الحراري"
            },
            new KeyWords
            {
                Id = 3,
                EnKeyword = "outdoor worker safety",
                ArKeyword = "معدات سلامة العمال"
            },
            new KeyWords
            {
                Id = 4,
                EnKeyword = "personal cooling technology",
                ArKeyword = "تقنية التبريد الشخصية"
            },
            new KeyWords
            {
                Id = 5,
                EnKeyword = "sun protection gear",
                ArKeyword = "ملابس عملية للطقس الحار"
            },
            new KeyWords
            {
                Id =6,
                EnKeyword = "construction worker cooling",
                ArKeyword = "تبريد للعمال في الهواء الطلق"
            },
            new KeyWords
            {
                Id =7,
                EnKeyword = "smart safety wearables",
                ArKeyword = "حماية من حرارة الشمس"
            },
            new KeyWords
            {
                Id = 8,
                EnKeyword = "agricultural worker protection",
                ArKeyword = "معدات تبريد للعمال"
            },
            new KeyWords
            {
                Id = 9,
                EnKeyword = "security team equipment",
                ArKeyword = "حلول الحرارة الشديدة"
            },
            new KeyWords
            {
                Id = 10,
                EnKeyword = "extreme heat solutions",
                ArKeyword = "تتبريد للعمال الزراعيين"
            });

            //------------------------------------------------------------------------------------------
            //=============================== KeyWords ===============================================

            builder.Entity<Pixels>().HasData(
            new Pixels
            {
                Id = 1,
                PixelsApp = "Google",
                PixelsCode = "<script>console.log('Pixels Google');</script>"
            },
            new Pixels
            {
                Id = 2,
                PixelsApp = "Facebook",
                PixelsCode = "<script> console.log('Pixels Facebook'); </script>"
            },
            new Pixels
            {
                Id = 3,
                PixelsApp = "TikTok",
                PixelsCode = "<script> console.log('Pixels TikTok'); </script>"
            });
        }
    }
}

