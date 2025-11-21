using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroBanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text_One = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text_Two = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text_Three = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Three = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroBanner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnKeyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArKeyword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnPageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArPageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnMetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArMetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnMetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArMetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pixels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PixelsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PixelsCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pixels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HeroBanner",
                columns: new[] { "Id", "Image_One", "Image_Three", "Image_Two", "Text_One", "Text_Three", "Text_Two" },
                values: new object[] { 1, "construction-workers-sunset.jpg", "working-with-blueprint.jpg", "inspectors-with-sketch.jpg", "Your Trusted Partner in Comprehensive Security", "From property protection to event security — we offer a wide range of security services tailored individually to your needs.", "Dependable Cooling\nYou Can Trust — Anytime,\n Anywhere." });

            migrationBuilder.InsertData(
                table: "KeyWords",
                columns: new[] { "Id", "ArKeyword", "EnKeyword" },
                values: new object[,]
                {
                    { 1, "قناع تبريد قابل للارتداء", "wearable cooling mask" },
                    { 2, "حماية من الإجهاد الحراري", "heat stress protection" },
                    { 3, "معدات سلامة العمال", "outdoor worker safety" },
                    { 4, "تقنية التبريد الشخصية", "personal cooling technology" },
                    { 5, "ملابس عملية للطقس الحار", "sun protection gear" },
                    { 6, "تبريد للعمال في الهواء الطلق", "construction worker cooling" },
                    { 7, "حماية من حرارة الشمس", "smart safety wearables" },
                    { 8, "معدات تبريد للعمال", "agricultural worker protection" },
                    { 9, "حلول الحرارة الشديدة", "security team equipment" },
                    { 10, "تتبريد للعمال الزراعيين", "extreme heat solutions" }
                });

            migrationBuilder.InsertData(
                table: "MetaPages",
                columns: new[] { "Id", "ArMetaDescription", "ArMetaTitle", "ArPageTitle", "EnMetaDescription", "EnMetaTitle", "EnPageTitle", "Page" },
                values: new object[] { 1, "SaVest شركة مبتكرة ملتزمة بتطوير حلول ذكية قابلة للارتداء تُعزز السلامة والراحة في البيئات القاسية. انطلاقًا من فهمها العميق للتحديات التي يواجهها العاملون في الهواء الطلق، تُصمم SaVest منتجات عملية وعالية الأداء مُصممة خصيصًا لتلبية احتياجات العالم الحقيقي.", "الرئيسية", "الرئيسية", "SaVest is an innovative company committed to developing smart, wearable solutions that enhance safety and comfort in extreme environments. Born from a deep understanding of the challenges faced by outdoor workers, SaVest designs practical, high-performance products tailored to real-world needs.", "Home", "Home", "Home" });

            migrationBuilder.InsertData(
                table: "Pixels",
                columns: new[] { "Id", "PixelsApp", "PixelsCode" },
                values: new object[,]
                {
                    { 1, "Google", "<script>console.log('Pixels Google');</script>" },
                    { 2, "Facebook", "<script> console.log('Pixels Facebook'); </script>" },
                    { 3, "TikTok", "<script> console.log('Pixels TikTok'); </script>" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroBanner");

            migrationBuilder.DropTable(
                name: "KeyWords");

            migrationBuilder.DropTable(
                name: "MetaPages");

            migrationBuilder.DropTable(
                name: "Pixels");
        }
    }
}
