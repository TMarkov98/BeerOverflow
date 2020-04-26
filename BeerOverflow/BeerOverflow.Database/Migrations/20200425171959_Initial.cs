using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BeerOverflow.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breweries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    BanReason = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    BreweryId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AlcoholByVolume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beers_BeerTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BeerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeersDrank",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeersDrank", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_BeersDrank_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeersDrank_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.BeerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Likes_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Text = table.Column<string>(nullable: false),
                    TargetBeerId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Beers_TargetBeerId",
                        column: x => x.TargetBeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistBeers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistBeers", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_WishlistBeers_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistBeers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(2347), null, false, null, "Pale Lager" },
                    { 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3982), null, false, null, "Bock" },
                    { 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3966), null, false, null, "Mead" },
                    { 11, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3951), null, false, null, "Pilsner" },
                    { 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3935), null, false, null, "Stout" },
                    { 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3918), null, false, null, "Porter" },
                    { 8, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3902), null, false, null, "Brown Ale" },
                    { 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3997), null, false, null, "Cider" },
                    { 6, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3871), null, false, null, "Amber Ale" },
                    { 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3853), null, false, null, "IPA" },
                    { 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3834), null, false, null, "Pale Ale" },
                    { 3, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3776), null, false, null, "Hefewizen" },
                    { 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3726), null, false, null, "Blonde Ale" },
                    { 7, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(3887), null, false, null, "Irish Red Ale" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 169, "PK", "Pakistan" },
                    { 168, "OM", "Oman" },
                    { 167, "NO", "Norway" },
                    { 166, "MP", "Northern Mariana Islands" },
                    { 165, "MK", "North Macedonia" },
                    { 162, "NU", "Niue" },
                    { 163, "NF", "Norfolk Island" },
                    { 161, "NG", "Nigeria" },
                    { 160, "NE", "Niger" },
                    { 159, "NI", "Nicaragua" },
                    { 170, "PW", "Palau" },
                    { 164, "KP", "North Korea" },
                    { 171, "PS", "Palestinian Authority" },
                    { 178, "PL", "Poland" },
                    { 173, "PG", "Papua New Guinea" },
                    { 174, "PY", "Paraguay" },
                    { 175, "PE", "Peru" },
                    { 176, "PH", "Philippines" },
                    { 177, "PN", "Pitcairn Islands" },
                    { 158, "NZ", "New Zealand" },
                    { 179, "PT", "Portugal" },
                    { 180, "PR", "Puerto Rico" },
                    { 181, "QA", "Qatar" },
                    { 182, "RE", "Réunion" },
                    { 183, "RO", "Romania" },
                    { 184, "RU", "Russia" },
                    { 185, "RW", "Rwanda" },
                    { 172, "PA", "Panama" },
                    { 157, "NC", "New Caledonia" },
                    { 150, "MA", "Morocco" },
                    { 155, "NP", "Nepal" },
                    { 127, "LY", "Libya" },
                    { 128, "LI", "Liechtenstein" },
                    { 129, "LT", "Lithuania" },
                    { 130, "LU", "Luxembourg" },
                    { 131, "MO", "Macao SAR" },
                    { 132, "MG", "Madagascar" },
                    { 133, "MW", "Malawi" },
                    { 134, "MY", "Malaysia" },
                    { 135, "MV", "Maldives" },
                    { 136, "ML", "Mali" },
                    { 137, "MT", "Malta" },
                    { 138, "MH", "Marshall Islands" },
                    { 139, "MQ", "Martinique" },
                    { 156, "NL", "Netherlands" },
                    { 140, "MR", "Mauritania" },
                    { 142, "YT", "Mayotte" },
                    { 143, "MX", "Mexico" },
                    { 144, "FM", "Micronesia" },
                    { 145, "MD", "Moldova" },
                    { 146, "MC", "Monaco" },
                    { 147, "MN", "Mongolia" },
                    { 148, "ME", "Montenegro" },
                    { 149, "MS", "Montserrat" },
                    { 186, "BL", "Saint Barthélemy" },
                    { 151, "MZ", "Mozambique" },
                    { 152, "MM", "Myanmar" },
                    { 153, "NA", "Namibia" },
                    { 154, "NR", "Nauru" },
                    { 141, "MU", "Mauritius" },
                    { 187, "KN", "Saint Kitts and Nevis" },
                    { 194, "ST", "São Tomé and Príncipe" },
                    { 189, "MF", "Saint Martin" },
                    { 222, "TG", "Togo" },
                    { 223, "TK", "Tokelau" },
                    { 224, "TO", "Tonga" },
                    { 225, "TT", "Trinidad and Tobago" },
                    { 226, "TN", "Tunisia" },
                    { 227, "TR", "Turkey" },
                    { 228, "TM", "Turkmenistan" },
                    { 229, "TC", "Turks and Caicos Islands" },
                    { 230, "TV", "Tuvalu" },
                    { 231, "UM", "U.S. Outlying Islands" },
                    { 232, "VI", "U.S. Virgin Islands" },
                    { 233, "UG", "Uganda" },
                    { 234, "UA", "Ukraine" },
                    { 235, "AE", "United Arab Emirates" },
                    { 236, "GB", "United Kingdom" },
                    { 237, "US", "United States" },
                    { 238, "UY", "Uruguay" },
                    { 239, "UZ", "Uzbekistan" },
                    { 240, "VU", "Vanuatu" },
                    { 241, "VA", "Vatican City" },
                    { 242, "VE", "Venezuela" },
                    { 243, "VN", "Vietnam" },
                    { 244, "WF", "Wallis and Futuna" },
                    { 245, "001", "World" },
                    { 246, "YE", "Yemen" },
                    { 247, "ZM", "Zambia" },
                    { 248, "ZW", "Zimbabwe" },
                    { 221, "TL", "Timor-Leste" },
                    { 220, "TH", "Thailand" },
                    { 219, "TZ", "Tanzania" },
                    { 218, "TJ", "Tajikistan" },
                    { 190, "PM", "Saint Pierre and Miquelon" },
                    { 191, "VC", "Saint Vincent and the Grenadines" },
                    { 192, "WS", "Samoa" },
                    { 193, "SM", "San Marino" },
                    { 126, "LR", "Liberia" },
                    { 195, "SA", "Saudi Arabia" },
                    { 196, "SN", "Senegal" },
                    { 197, "RS", "Serbia" },
                    { 198, "SC", "Seychelles" },
                    { 199, "SL", "Sierra Leone" },
                    { 200, "SG", "Singapore" },
                    { 201, "SX", "Sint Maarten" },
                    { 202, "SK", "Slovakia" },
                    { 188, "LC", "Saint Lucia" },
                    { 203, "SI", "Slovenia" },
                    { 205, "SO", "Somalia" },
                    { 206, "ZA", "South Africa" },
                    { 207, "SS", "South Sudan" },
                    { 208, "ES", "Spain" },
                    { 209, "LK", "Sri Lanka" },
                    { 210, "SH", "St Helena, Ascension, Tristan da Cunha" },
                    { 211, "SD", "Sudan" },
                    { 212, "SR", "Suriname" },
                    { 213, "SJ", "Svalbard and Jan Mayen" },
                    { 214, "SE", "Sweden" },
                    { 215, "CH", "Switzerland" },
                    { 216, "SY", "Syria" },
                    { 217, "TW", "Taiwan" },
                    { 204, "SB", "Solomon Islands" },
                    { 125, "LS", "Lesotho" },
                    { 119, "KW", "Kuwait" },
                    { 123, "LV", "Latvia" },
                    { 33, "BN", "Brunei" },
                    { 34, "BG", "Bulgaria" },
                    { 35, "BF", "Burkina Faso" },
                    { 36, "BI", "Burundi" },
                    { 37, "CV", "Cabo Verde" },
                    { 38, "KH", "Cambodia" },
                    { 39, "CM", "Cameroon" },
                    { 40, "CA", "Canada" },
                    { 41, "029", "Caribbean" },
                    { 42, "KY", "Cayman Islands" },
                    { 43, "CF", "Central African Republic" },
                    { 44, "TD", "Chad" },
                    { 45, "CL", "Chile" },
                    { 46, "CN", "China" },
                    { 47, "CX", "Christmas Island" },
                    { 48, "CC", "Cocos (Keeling) Islands" },
                    { 49, "CO", "Colombia" },
                    { 50, "KM", "Comoros" },
                    { 51, "CG", "Congo" },
                    { 52, "CD", "Congo (DRC)" },
                    { 53, "CK", "Cook Islands" },
                    { 54, "CR", "Costa Rica" },
                    { 55, "CI", "Côte d’Ivoire" },
                    { 56, "HR", "Croatia" },
                    { 57, "CU", "Cuba" },
                    { 58, "CW", "Curaçao" },
                    { 59, "CY", "Cyprus" },
                    { 32, "VG", "British Virgin Islands" },
                    { 31, "IO", "British Indian Ocean Territory" },
                    { 30, "BR", "Brazil" },
                    { 29, "BW", "Botswana" },
                    { 1, "AF", "Afghanistan" },
                    { 2, "AX", "Åland Islands" },
                    { 3, "AL", "Albania" },
                    { 4, "DZ", "Algeria" },
                    { 5, "AS", "American Samoa" },
                    { 6, "AD", "Andorra" },
                    { 7, "AO", "Angola" },
                    { 8, "AI", "Anguilla" },
                    { 9, "AG", "Antigua and Barbuda" },
                    { 10, "AR", "Argentina" },
                    { 11, "AM", "Armenia" },
                    { 12, "AW", "Aruba" },
                    { 13, "AU", "Australia" },
                    { 60, "CZ", "Czechia" },
                    { 14, "AT", "Austria" },
                    { 16, "BS", "Bahamas" },
                    { 17, "BH", "Bahrain" },
                    { 18, "BD", "Bangladesh" },
                    { 19, "BB", "Barbados" },
                    { 20, "BY", "Belarus" },
                    { 21, "BE", "Belgium" },
                    { 22, "BZ", "Belize" },
                    { 23, "BJ", "Benin" },
                    { 24, "BM", "Bermuda" },
                    { 25, "BT", "Bhutan" },
                    { 26, "BO", "Bolivia" },
                    { 27, "BQ", "Bonaire, Sint Eustatius and Saba" },
                    { 28, "BA", "Bosnia and Herzegovina" },
                    { 15, "AZ", "Azerbaijan" },
                    { 124, "LB", "Lebanon" },
                    { 61, "DK", "Denmark" },
                    { 63, "DM", "Dominica" },
                    { 95, "GW", "Guinea-Bissau" },
                    { 96, "GY", "Guyana" },
                    { 97, "HT", "Haiti" },
                    { 98, "HN", "Honduras" },
                    { 99, "HK", "Hong Kong SAR" },
                    { 100, "HU", "Hungary" },
                    { 101, "IS", "Iceland" },
                    { 102, "IN", "India" },
                    { 103, "ID", "Indonesia" },
                    { 104, "IR", "Iran" },
                    { 105, "IQ", "Iraq" },
                    { 106, "IE", "Ireland" },
                    { 107, "IM", "Isle of Man" },
                    { 108, "IL", "Israel" },
                    { 109, "IT", "Italy" },
                    { 110, "JM", "Jamaica" },
                    { 111, "JP", "Japan" },
                    { 112, "JE", "Jersey" },
                    { 113, "JO", "Jordan" },
                    { 114, "KZ", "Kazakhstan" },
                    { 115, "KE", "Kenya" },
                    { 116, "KI", "Kiribati" },
                    { 117, "KR", "Korea" },
                    { 118, "XK", "Kosovo" },
                    { 120, "KG", "Kyrgyzstan" },
                    { 121, "LA", "Laos" },
                    { 122, "419", "Latin America" },
                    { 62, "DJ", "Djibouti" },
                    { 93, "GG", "Guernsey" },
                    { 94, "GN", "Guinea" },
                    { 91, "GU", "Guam" },
                    { 64, "DO", "Dominican Republic" },
                    { 65, "EC", "Ecuador" },
                    { 66, "EG", "Egypt" },
                    { 67, "SV", "El Salvador" },
                    { 68, "GQ", "Equatorial Guinea" },
                    { 69, "ER", "Eritrea" },
                    { 70, "EE", "Estonia" },
                    { 71, "SZ", "Eswatini" },
                    { 72, "ET", "Ethiopia" },
                    { 73, "150", "Europe" },
                    { 74, "FK", "Falkland Islands" },
                    { 75, "FO", "Faroe Islands" },
                    { 92, "GT", "Guatemala" },
                    { 76, "FJ", "Fiji" },
                    { 78, "FR", "France" },
                    { 90, "GP", "Guadeloupe" },
                    { 89, "GD", "Grenada" },
                    { 88, "GL", "Greenland" },
                    { 87, "GR", "Greece" },
                    { 77, "FI", "Finland" },
                    { 85, "GH", "Ghana" },
                    { 86, "GI", "Gibraltar" },
                    { 83, "GE", "Georgia" },
                    { 82, "GM", "Gambia" },
                    { 81, "GA", "Gabon" },
                    { 80, "PF", "French Polynesia" },
                    { 79, "GF", "French Guiana" },
                    { 84, "DE", "Germany" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 2, "User" },
                    { 1, "Admin" },
                    { 3, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 2, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1010), null, false, null, "Ah! Brew Works Sofia" },
                    { 25, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1487), null, false, null, "Mad Panda Brewery Sofia" },
                    { 26, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1503), null, false, null, "Meadly Sofia" },
                    { 27, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1518), null, false, null, "Metalhead Brewery Burgas" },
                    { 28, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1533), null, false, null, "Pirinsko Pivo Blagoevgrad" },
                    { 29, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1549), null, false, null, "Pivoteka Sofia" },
                    { 30, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1565), null, false, null, "Pivovaren Zavod Kamenitsa Plovdiv" },
                    { 31, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1580), null, false, null, "Pivovarna 359 Mramor" },
                    { 32, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1596), null, false, null, "Pivovarna Britos Veliko Tarnovo" },
                    { 33, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1612), null, false, null, "Pivovarna Zagorka Stara Zagora" },
                    { 34, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1630), null, false, null, "Rhombus Craft Brewery Pazardzhik" },
                    { 35, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1645), null, false, null, "Royal Cat Varna" },
                    { 36, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1661), null, false, null, "Shumensko Pivo Shumen" },
                    { 37, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1677), null, false, null, "Trima i Dvama Sliven" },
                    { 38, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1692), null, false, null, "White Stork Beer Company Sofia" },
                    { 39, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1707), null, false, null, "The Black Sheep Varna" },
                    { 40, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1723), null, false, null, "Meltum Brewery Lovech" },
                    { 1, 87, new DateTime(2020, 4, 25, 20, 19, 59, 508, DateTimeKind.Local).AddTicks(2330), null, false, null, "Mythos Breweries" },
                    { 24, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1471), null, false, null, "Birariya Tryavna" },
                    { 22, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1406), null, false, null, "Kazan Artizan Sofia" },
                    { 23, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1454), null, false, null, "Lomsko Pivo AD Lom" },
                    { 10, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1215), null, false, null, "Boliarka Brewery Veliko Tarnovo" },
                    { 4, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1111), null, false, null, "Astika Brewery Haskovo" },
                    { 5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1128), null, false, null, "Beer Bastards Burgas" },
                    { 6, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1148), null, false, null, "Beerbox Sofia" },
                    { 7, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1164), null, false, null, "Beershop-BG Sofia" },
                    { 8, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1180), null, false, null, "Birariya River Side Sofia" },
                    { 9, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1197), null, false, null, "Blek Pine Sofia" },
                    { 21, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1390), null, false, null, "Jägerhof Plovdiv" },
                    { 11, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1231), null, false, null, "Bro Beer Sofia" },
                    { 12, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1247), null, false, null, "Brothers Brew Varna" },
                    { 13, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1262), null, false, null, "Pivovarnata Burgas" },
                    { 14, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1279), null, false, null, "Can Supply Blagoevgrad" },
                    { 15, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1294), null, false, null, "Cohones Brewery Sofia" },
                    { 16, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1311), null, false, null, "Dorst Sofia" },
                    { 17, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1326), null, false, null, "Dunav Craft Brewery Ruse" },
                    { 18, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1343), null, false, null, "Glarus Craft Brewing Company Varna" },
                    { 19, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1359), null, false, null, "Halbite Sofia" },
                    { 20, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1375), null, false, null, "Hills Brewery Perushtitsa" },
                    { 3, 34, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(1089), null, false, null, "Ailyak Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BanReason", "CreatedOn", "DeletedOn", "Email", "IsBanned", "IsDeleted", "ModifiedOn", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(1237), null, "Gosho@biri.com", false, false, null, "NaGoshoParolata", 2, "Gosho" },
                    { 3, null, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(1304), null, "Tosho@biri.com", false, false, null, "NaToshoParolata", 2, "Tosho" },
                    { 1, null, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(9671), null, "Pesho@biri.com", false, false, null, "NaPeshoParolata", 2, "Pesho" },
                    { 4, null, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(1328), null, "Slavcho@biri.com", false, false, null, "NaSlavchoParolata", 2, "Slavcho" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 2, 6.4000000000000004, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7577), null, false, null, "Ah! 7 - Mursalski Red Ale", 7 },
                    { 234, 4.0, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2609), null, false, null, "Kronberg", 1 },
                    { 233, 4.0, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2589), null, false, null, "Nazdrave Svetlo", 1 },
                    { 232, 5.5, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2541), null, false, null, "Britos Opusheno", 9 },
                    { 231, 5.0, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2523), null, false, null, "Britos Hoppy Blond", 2 },
                    { 230, 4.5, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2503), null, false, null, "Britos Contintental Lager", 1 },
                    { 229, 4.5, 32, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2484), null, false, null, "Britos", 1 },
                    { 228, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2465), null, false, null, "Divo Pivo First Birthday Edition", 2 },
                    { 227, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2445), null, false, null, "Divo Pivo 3rd of March", 2 },
                    { 226, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2425), null, false, null, "Divo Pivo Weiss", 3 },
                    { 225, 4.5999999999999996, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2406), null, false, null, "Divo Pivo Kapana Ale", 4 },
                    { 224, 6.2000000000000002, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2387), null, false, null, "Divo Pivo Gaillot", 10 },
                    { 223, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2367), null, false, null, "Na Peikata", 5 },
                    { 222, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2348), null, false, null, "Na Specialnata Peika", 5 },
                    { 221, 4.7000000000000002, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2328), null, false, null, "Samets", 7 },
                    { 220, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2308), null, false, null, "Kotka & Mishka Session IPA", 5 },
                    { 219, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2289), null, false, null, "Divo Pivo DDH DDH", 4 },
                    { 218, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2270), null, false, null, "Divo Pivo Session IPA", 5 },
                    { 235, 6.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2629), null, false, null, "Stolichno Bock", 13 },
                    { 216, 5.5999999999999996, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2251), null, false, null, "Divo Pivo Red Ale", 7 },
                    { 236, 6.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2648), null, false, null, "Stolichno Weiss", 3 },
                    { 238, 6.0, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2687), null, false, null, "Stolichno Amber Pils", 6 },
                    { 255, 6.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3066), null, false, null, "Rhombus Aloha IPA", 5 },
                    { 254, 7.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3047), null, false, null, "Rhombus Imperial Porter", 9 },
                    { 253, 7.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3028), null, false, null, "Rhombus Dirty", 10 },
                    { 252, 9.3000000000000007, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3005), null, false, null, "Rhombus Impreial Porter (Barrel Aged)", 9 },
                    { 251, 4.9000000000000004, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2957), null, false, null, "Ariana Varka7", 1 },
                    { 250, 5.0, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2938), null, false, null, "Amstel Dark", 8 },
                    { 249, 4.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2919), null, false, null, "Kradetsut na Yabulki Krade I Vishni", 14 },
                    { 248, 4.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2899), null, false, null, "Kradetsut na Yabulki Krade I Slivi", 14 },
                    { 247, 5.0, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2880), null, false, null, "Zagorka Gold", 1 },
                    { 246, 4.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2861), null, false, null, "Ariana", 1 },
                    { 245, 5.0, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2841), null, false, null, "Zagorka Spetsialno", 1 },
                    { 244, 4.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2822), null, false, null, "Zagorka Retro", 1 },
                    { 243, 4.7999999999999998, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2803), null, false, null, "Zagorka IPA", 5 },
                    { 242, 6.0, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2784), null, false, null, "Zagorka Rezerva", 7 },
                    { 241, 5.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2765), null, false, null, "Ariana Tumno", 8 },
                    { 240, 4.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2745), null, false, null, "Kradetsut na Yabulki Sochna Yabulka", 14 },
                    { 239, 5.5, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2705), null, false, null, "Stolichno Pale Ale", 4 },
                    { 237, 7.0999999999999996, 33, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2668), null, false, null, "Stolichno Pale Bock", 13 },
                    { 215, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2231), null, false, null, "Divo Pivo HD Limited", 4 },
                    { 214, 4.5, 31, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2212), null, false, null, "Divo Pivo", 4 },
                    { 213, 4.4000000000000004, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2192), null, false, null, "Pleven Svetlo", 1 },
                    { 190, 10.5, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1650), null, false, null, "Metalhead Sweet Stout of Mine Barrel Aged: Jack Daniel's", 10 },
                    { 189, 4.2000000000000002, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1631), null, false, null, "Metalhead Pleasure and Pain", 3 },
                    { 188, 5.9000000000000004, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1612), null, false, null, "Metalhead Turbo Lover", 5 },
                    { 187, 7.0999999999999996, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1593), null, false, null, "Metalhead King Nothing", 5 },
                    { 186, 7.0, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1574), null, false, null, "Metalhead Supermassive Black IPA", 8 },
                    { 185, 4.5999999999999996, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1554), null, false, null, "Metalhead Cinn City", 7 },
                    { 184, 6.7000000000000002, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1535), null, false, null, "Metalhead Headbangers Boil", 5 },
                    { 183, 5.4000000000000004, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1516), null, false, null, "Metalhead Lickitup", 4 },
                    { 182, 6.9000000000000004, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1497), null, false, null, "Metalhead Your Girlfriend's Girlfriend", 5 },
                    { 181, 10.5, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1478), null, false, null, "Metalhead Sweet Stout of Mine", 10 },
                    { 180, 5.5, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1459), null, false, null, "Metalhead Space Lord", 1 },
                    { 179, 10.0, 26, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1440), null, false, null, "Meadly Zhiva Medovina", 12 },
                    { 178, 12.0, 26, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1420), null, false, null, "Meadly Live Mead With Herbs", 12 },
                    { 177, 13.0, 26, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1401), null, false, null, "Meadly Traditional Mead", 12 },
                    { 176, 11.0, 26, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1381), null, false, null, "Meadly Sweet Mead", 12 },
                    { 175, 5.5, 25, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1362), null, false, null, "Mad Panda PsycHOP Therapy", 4 },
                    { 174, 6.5999999999999996, 25, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1340), null, false, null, "Mad Panda Powder Mafia", 10 },
                    { 191, 3.7999999999999998, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1669), null, false, null, "Metalhead Running Mild", 4 },
                    { 192, 6.2000000000000002, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1688), null, false, null, "Metalhead Metalingus", 9 },
                    { 193, 6.5, 27, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1707), null, false, null, "Metalhead Hop Suey", 5 },
                    { 194, 4.4000000000000004, 28, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1794), null, false, null, "Pirinsko Svetlo Pivo", 1 },
                    { 212, 9.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2142), null, false, null, "Kamenitza Tvurdo", 11 },
                    { 211, 5.0999999999999996, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2123), null, false, null, "Kamenitza Live", 1 },
                    { 210, 5.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2104), null, false, null, "Kamenitza Pshenichno", 3 },
                    { 209, 6.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2085), null, false, null, "Kamenitza Tumno", 8 },
                    { 208, 4.9000000000000004, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2066), null, false, null, "Kamenitza Nefiltrirano", 3 },
                    { 207, 4.0999999999999996, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2047), null, false, null, "Pleven Svetlo Pivo", 1 },
                    { 206, 5.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2028), null, false, null, "Kamenitza Bialo", 1 },
                    { 205, 4.4000000000000004, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(2008), null, false, null, "Kamenitza Cherveno", 6 },
                    { 256, 5.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3087), null, false, null, "Rhombus Weizen IPA", 5 },
                    { 204, 4.0999999999999996, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1989), null, false, null, "Slavena Svetlo", 1 },
                    { 202, 5.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1951), null, false, null, "Kamenitza Extra", 1 },
                    { 201, 5.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1932), null, false, null, "Kamenitza Lev", 1 },
                    { 200, 5.0, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1912), null, false, null, "Kamenitza Tamno", 8 },
                    { 199, 4.7999999999999998, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1893), null, false, null, "Kamenitza Staro Pivo", 11 },
                    { 198, 4.0, 29, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1873), null, false, null, "Pivoteka Hala", 1 },
                    { 197, 4.7000000000000002, 28, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1853), null, false, null, "Pirinsko Tumno Pivo", 8 },
                    { 196, 4.4000000000000004, 28, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1834), null, false, null, "Pirinsko Ledeno", 1 },
                    { 195, 4.4000000000000004, 28, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1815), null, false, null, "Pirinsko Mlado Pivo", 1 },
                    { 203, 4.4000000000000004, 30, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1970), null, false, null, "Kamenitza 1881", 1 },
                    { 257, 5.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3106), null, false, null, "Rhombus English Porter", 9 },
                    { 258, 6.2999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3125), null, false, null, "Rhombus Dr. Brettish", 7 },
                    { 259, 6.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3148), null, false, null, "Rhombus Dr. Cherry Kriek", 7 },
                    { 309, 7.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4425), null, false, null, "White Stork Cosmic Debris", 5 },
                    { 308, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4405), null, false, null, "White Stork Boys Don't Cry-o", 1 },
                    { 307, 9.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4386), null, false, null, "White Stork White Stout", 10 },
                    { 306, 6.7000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4366), null, false, null, "White Stork 1908 Stout", 10 },
                    { 305, 7.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4347), null, false, null, "White Stork Tropikalia IPA", 5 },
                    { 304, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4328), null, false, null, "Trima I Dvama Black Head Stout", 10 },
                    { 303, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4309), null, false, null, "Trima I Dvama Chisto I Prosto", 2 },
                    { 302, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4289), null, false, null, "Trima I Dvama Chai Malko", 2 },
                    { 301, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4270), null, false, null, "Trima I Dvama Unlackee", 7 },
                    { 300, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4250), null, false, null, "Trima I Dvama Ancient Meridian", 2 },
                    { 299, 5.5999999999999996, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4231), null, false, null, "Trima I Dvama Smoking Hot", 9 },
                    { 298, 4.2000000000000002, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4212), null, false, null, "Trima I Dvama Janka", 4 },
                    { 297, 7.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4193), null, false, null, "Trima I Dvama Ginger Sucker Happy Ginger Ale", 6 },
                    { 296, 5.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4173), null, false, null, "Trima I Dvama Bloody Muddy", 7 },
                    { 295, 5.5, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4154), null, false, null, "Trima I Dvama Mashin' Pumpkins", 6 },
                    { 294, 7.0, 37, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4135), null, false, null, "Trima I Dvama CHIPA", 5 },
                    { 293, 4.2999999999999998, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4116), null, false, null, "Shumensko Svetlo Pivo", 6 },
                    { 310, 5.5, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4473), null, false, null, "White Stork Pushing The Limets", 3 },
                    { 311, 3.5, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4493), null, false, null, "White Stork Rai", 5 },
                    { 312, 5.5, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4513), null, false, null, "White Stork Original", 4 },
                    { 313, 6.7000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4532), null, false, null, "White Stork Dark Side", 10 },
                    { 331, 4.9000000000000004, 40, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4912), null, false, null, "G-n Xops Pale Ale V2.0", 4 },
                    { 330, 6.0, 40, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4892), null, false, null, "G-n Xops NEIPA V2.0", 5 },
                    { 329, 6.5, 40, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4872), null, false, null, "G-n Xops Coconut Milk Porter", 9 },
                    { 327, 5.0, 39, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4803), null, false, null, "Zlatna Varna Amber", 6 },
                    { 328, 4.9000000000000004, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4823), null, false, null, "Zlatna Varna Pilsner", 11 },
                    { 326, 5.5, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4784), null, false, null, "White Stork Summer", 4 },
                    { 325, 10.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4765), null, false, null, "White Stork Intergalactic DIPA DDH", 5 },
                    { 324, 5.7000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4746), null, false, null, "White Stork Borderless", 6 },
                    { 292, 4.5999999999999996, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4096), null, false, null, "Shumensko Premium", 1 },
                    { 323, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4726), null, false, null, "White Stork Kinky Afro", 11 },
                    { 321, 7.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4688), null, false, null, "White Stork Take Me Somewhere Nice", 5 },
                    { 320, 7.0, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4669), null, false, null, "White Stork Tropikalia V2.0", 5 },
                    { 319, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4648), null, false, null, "White Stork Just a Pilsner", 11 },
                    { 318, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4629), null, false, null, "White Stork Into The Galaxy", 11 },
                    { 317, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4610), null, false, null, "White Stork Hop Along", 11 },
                    { 316, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4590), null, false, null, "White Stork BOOGIEon by Ramsey Hercules", 11 },
                    { 315, 9.0999999999999996, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4571), null, false, null, "White Stork Mutants", 5 },
                    { 314, 3.6000000000000001, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4551), null, false, null, "White Stork Sofiiski Weisse", 3 },
                    { 322, 4.2000000000000002, 38, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4707), null, false, null, "White Stork Dry Hopped House Pilsner", 11 },
                    { 173, 6.7000000000000002, 25, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1289), null, false, null, "Mad Panda God Gave the Hops", 5 },
                    { 291, 5.2000000000000002, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4077), null, false, null, "Shumensko", 1 },
                    { 289, 5.0999999999999996, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3988), null, false, null, "Shumensko Cherveno", 7 },
                    { 276, 4.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3510), null, false, null, "Rhombus Pale Ale", 4 },
                    { 275, 5.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3491), null, false, null, "Rhombus Weiss", 3 },
                    { 274, 4.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3472), null, false, null, "Rhombus Irish Red", 7 },
                    { 273, 7.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3452), null, false, null, "Rhombus Pardon I'm Brut", 5 },
                    { 272, 4.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3432), null, false, null, "Rhombus AnimAle", 1 },
                    { 271, 5.0999999999999996, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3413), null, false, null, "Rhombus Christmas Fever", 10 },
                    { 270, 8.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3393), null, false, null, "Rhombus The Crow", 9 },
                    { 269, 6.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3373), null, false, null, "Rhombus Orpheus Gruit", 7 },
                    { 268, 9.1999999999999993, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3354), null, false, null, "Rhombus Tok i Zhica", 10 },
                    { 267, 3.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3334), null, false, null, "Rhombus Hakuna Matata", 3 },
                    { 266, 6.4000000000000004, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3315), null, false, null, "Rhombus Mint Nights", 10 },
                    { 265, 4.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3295), null, false, null, "Rhombus Lavender Nights", 9 },
                    { 264, 3.8999999999999999, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3276), null, false, null, "Rhombus Violet", 7 },
                    { 263, 6.2999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3257), null, false, null, "Rhombus In the Blooming Rye", 5 },
                    { 262, 7.5999999999999996, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3237), null, false, null, "Rhombus Pearl", 6 },
                    { 261, 6.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3187), null, false, null, "Rhombus Apfel Strudel", 8 },
                    { 260, 6.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3168), null, false, null, "Rhombus Alba - White IPA", 5 },
                    { 277, 5.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3529), null, false, null, "Rhombus Dark Steel", 5 },
                    { 278, 4.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3548), null, false, null, "Rhombus St. Patrick's Beer", 4 },
                    { 279, 3.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3568), null, false, null, "Rhombus Catch the Wave", 5 },
                    { 333, 4.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3588), null, false, null, "Rhombus Pilsner", 11 },
                    { 288, 5.5, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3969), null, false, null, "Shumensko Tumno", 8 },
                    { 287, 5.5999999999999996, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3950), null, false, null, "Shumensko Kolektsiya Na Pivovarite Belgiyski Stil", 3 },
                    { 286, 6.2000000000000002, 35, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3930), null, false, null, "Royal Cat", 3 },
                    { 285, 4.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3910), null, false, null, "Rhombus Svetlo", 4 },
                    { 284, 6.5999999999999996, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3891), null, false, null, "Rhombus Imperial Ale", 10 },
                    { 283, 4.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3871), null, false, null, "Rhombus Spetsialno", 7 },
                    { 282, 6.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3852), null, false, null, "Rhombus Belgian Blond", 3 },
                    { 281, 5.7000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3833), null, false, null, "Rhombus Flanders Brown Ale Special Selection", 8 },
                    { 290, 5.4000000000000004, 36, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4055), null, false, null, "Shumnesko Kolektsiya na Pivovarite Cheshki Stil", 11 },
                    { 280, 6.7000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3812), null, false, null, "Rhombus Brown Ale", 8 },
                    { 341, 5.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3773), null, false, null, "Rhombus Breakfast Oatmeal Stout", 10 },
                    { 340, 4.5, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3754), null, false, null, "Rhombus Kirschtorte", 3 },
                    { 339, 6.2000000000000002, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3735), null, false, null, "Rhombus Boston Tea Party", 5 },
                    { 338, 6.0, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3717), null, false, null, "Rhombus Arriba Arriba", 9 },
                    { 337, 5.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3697), null, false, null, "Rhombus Black Widow", 5 },
                    { 336, 5.9000000000000004, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3678), null, false, null, "Rhombus Mart", 6 },
                    { 335, 5.4000000000000004, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3659), null, false, null, "Rhombus Belona", 5 },
                    { 334, 7.0999999999999996, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3638), null, false, null, "Rhombus Easter", 8 },
                    { 342, 5.7999999999999998, 34, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(3793), null, false, null, "Rhombus Star Anise Stout", 10 },
                    { 332, 4.5, 40, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(4931), null, false, null, "G-n Xops", 4 },
                    { 172, 5.2999999999999998, 25, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1269), null, false, null, "Mad Panda Cryo Bandit", 4 },
                    { 170, 5.0, 24, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1230), null, false, null, "Lucs Kehlibar", 8 },
                    { 62, 4.5999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8909), null, false, null, "Schweik Cheshko Pivo", 1 },
                    { 61, 5.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8889), null, false, null, "Boliarka Tumno", 8 },
                    { 60, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8870), null, false, null, "Blek Pine IPA Limited Edition", 5 },
                    { 59, 6.2000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8851), null, false, null, "Blek Pine Rye IPA", 5 },
                    { 58, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8831), null, false, null, "Blek Pine Sofia Metal Fest IPA", 5 },
                    { 57, 6.2000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8812), null, false, null, "Blek Pine Session", 5 },
                    { 56, 6.4000000000000004, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8793), null, false, null, "Blek Pine Seriez Peach", 4 },
                    { 55, 7.5999999999999996, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8774), null, false, null, "Blek Pine Divo Divo", 6 },
                    { 54, 5.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8755), null, false, null, "Blek Pine Summer Is Coming - Episode 2", 4 },
                    { 53, 5.4000000000000004, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8736), null, false, null, "Blek Pine Blanche De Citron", 1 },
                    { 52, 6.5999999999999996, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8716), null, false, null, "Blek Pine Chilli in the Hills Chipotle Hoppy Stout", 10 },
                    { 51, 9.0999999999999996, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8697), null, false, null, "Blek Pine Rum Pum Pum", 6 },
                    { 50, 6.5999999999999996, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8677), null, false, null, "Blek Pine Blek & Red", 10 },
                    { 49, 4.2999999999999998, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8658), null, false, null, "Blek Pine Sour Session", 5 },
                    { 48, 7.0, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8638), null, false, null, "Blek Pine New England", 5 },
                    { 47, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8604), null, false, null, "Blek Pine WCOS IPA", 5 },
                    { 46, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8555), null, false, null, "Blek Pine IPA", 5 },
                    { 63, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8928), null, false, null, "Balkansko Svetlo", 1 },
                    { 45, 7.2999999999999998, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8536), null, false, null, "Blek Pine Pumpking Ale", 7 },
                    { 64, 4.2999999999999998, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8947), null, false, null, "Boliarka Svetlo", 1 },
                    { 66, 5.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9019), null, false, null, "Kings Premium", 1 },
                    { 83, 5.9000000000000004, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9379), null, false, null, "Brothers Deutschamerikaner", 5 },
                    { 82, 4.0, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9331), null, false, null, "Brothers Brew Team Mosaic", 5 },
                    { 81, 5.5, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9312), null, false, null, "Brothers Brew Team Right As Rain", 6 },
                    { 80, 5.5999999999999996, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9292), null, false, null, "Brothers Brew Team Make Coffee Great Again", 10 },
                    { 79, 5.0, 11, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9274), null, false, null, "Bro Beer Importered Pig", 9 },
                    { 78, 3.7999999999999998, 11, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9254), null, false, null, "Bro Beer Fat Free Pig", 5 },
                    { 77, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9235), null, false, null, "Nashensko Svetlo", 1 },
                    { 76, 5.4000000000000004, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9216), null, false, null, "Boliarka Weiss", 1 },
                    { 75, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9196), null, false, null, "Stara Stolitsa Svetlo Pivo", 1 },
                    { 74, 5.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9176), null, false, null, "Boliarka Special", 1 },
                    { 73, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9156), null, false, null, "Kehlstein Premium Lager", 1 },
                    { 72, 4.5999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9137), null, false, null, "Peti Okean Jiva Bira", 11 },
                    { 71, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9118), null, false, null, "Diana Premium Lager", 1 },
                    { 70, 4.2999999999999998, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9097), null, false, null, "Boliarka Unpasteurised", 1 },
                    { 69, 3.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9078), null, false, null, "Tsarsko Svetlo", 1 },
                    { 68, 5.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9058), null, false, null, "Boliarka Fort Premium Lager 100% Malt", 1 },
                    { 67, 4.0999999999999996, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9039), null, false, null, "Boliarka Elba Svetlo Pivo", 1 },
                    { 65, 5.0, 10, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8966), null, false, null, "Diana Lager", 1 },
                    { 44, 4.7999999999999998, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8517), null, false, null, "Blek Pine Summer Is Coming", 4 },
                    { 43, 7.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8497), null, false, null, "Blek Pine Kokonut Porter", 9 },
                    { 42, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8478), null, false, null, "Blek Pine Rauchbier with Cocoa and Blek Pepper", 9 },
                    { 19, 5.0, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7992), null, false, null, "Astika Special", 1 },
                    { 18, 4.4000000000000004, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7973), null, false, null, "Burgasko Svetlo", 1 },
                    { 17, 4.9000000000000004, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7951), null, false, null, "Astika Lux Premium", 1 },
                    { 16, 4.5, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7932), null, false, null, "Astika Fine Quality Lager", 1 },
                    { 15, 6.5999999999999996, 3, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7913), null, false, null, "Ailyak Birthday IPA", 1 },
                    { 14, 6.0, 3, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7893), null, false, null, "Ailyak ProViotic", 5 },
                    { 13, 6.0, 3, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7874), null, false, null, "Ailyak Cryo DDH NEIPA", 5 },
                    { 12, 6.0, 3, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7854), null, false, null, "Ailyak Cryo Mosaic IPA", 5 },
                    { 11, 4.9000000000000004, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7835), null, false, null, "Ah! 9 - Indian Pale Ale", 4 },
                    { 10, 6.4000000000000004, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7811), null, false, null, "Ah! 23 - French Apple Cider", 14 },
                    { 9, 4.2000000000000002, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7733), null, false, null, "Ah! 9 - Kiss My Kvass", 8 },
                    { 8, 8.0, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7713), null, false, null, "Ah! 13 - Corruption Brown Ale", 8 },
                    { 7, 5.0, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7694), null, false, null, "Ah! 6 - Funky Janky", 6 },
                    { 6, 7.0, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7674), null, false, null, "Mr. Habi Benero", 10 },
                    { 5, 5.0, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7651), null, false, null, "Ah! Sofia Streets", 1 },
                    { 4, 5.2000000000000002, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7631), null, false, null, "Ah! 3 - Bulgarian Pale Ale", 4 },
                    { 3, 5.0, 2, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7610), null, false, null, "Ah! 5 - Bad Baba", 1 },
                    { 20, 5.0, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8012), null, false, null, "Haskovo Beck's", 1 },
                    { 34, 5.5999999999999996, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8323), null, false, null, "Astika Tumno", 8 }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 35, 4.4000000000000004, 4, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8343), null, false, null, "Astika Svetlo", 1 },
                    { 21, 6.7000000000000002, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8032), null, false, null, "Beer Bastards Basi Kefa", 5 },
                    { 41, 6.7000000000000002, 9, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8459), null, false, null, "Blek Pine Stout", 10 },
                    { 40, 5.2999999999999998, 8, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8440), null, false, null, "HBH Svetla Jiva Bira", 1 },
                    { 38, 5.5999999999999996, 8, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8401), null, false, null, "HBH Tumna Jiva Bira", 8 },
                    { 39, 4.7999999999999998, 7, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8421), null, false, null, "Beershop-BG Gaida", 1 },
                    { 37, 5.0, 6, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8382), null, false, null, "Beerbox Galleon Premium Lager", 1 },
                    { 36, 4.0, 6, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8363), null, false, null, "Beerbox Galleon Weiss", 1 },
                    { 33, 5.5, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8302), null, false, null, "Beer Bastards Toplo Takova", 6 },
                    { 32, 8.0, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8283), null, false, null, "Beer Bastards Dami Kanyat", 10 },
                    { 84, 4.7000000000000002, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9400), null, false, null, "Brothers Brew Team Hello, World!", 4 },
                    { 31, 9.6999999999999993, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8264), null, false, null, "Beer Bastards Tok i Zhica", 10 },
                    { 29, 7.0, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8223), null, false, null, "Beer Bastards Bone Chance", 9 },
                    { 28, 9.0, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8167), null, false, null, "Beer Bastards Solo New Garash Cake", 10 },
                    { 27, 4.4000000000000004, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8148), null, false, null, "Beer Bastards Edno Vreme", 11 },
                    { 26, 4.5999999999999996, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8128), null, false, null, "Beer Bastards Bash Maistora", 1 },
                    { 25, 6.5999999999999996, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8108), null, false, null, "Beer Bastards Opasen Char", 5 },
                    { 24, 4.7000000000000002, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8089), null, false, null, "Beer Bastards Freigeist Dirty Flamingo", 4 },
                    { 23, 5.7999999999999998, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8070), null, false, null, "Beer Bastards Faster Bastard", 5 },
                    { 22, 5.2000000000000002, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8051), null, false, null, "Beer Bastards Po-Poleka", 5 },
                    { 30, 4.4000000000000004, 5, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(8244), null, false, null, "Beer Bastards Gusto Maina", 11 },
                    { 85, 8.1999999999999993, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9420), null, false, null, "Brothers Brew Team Little Princess", 10 },
                    { 86, 7.2000000000000002, 12, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9439), null, false, null, "Brothers Brew Team Liberation", 5 },
                    { 87, 5.4000000000000004, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9459), null, false, null, "Veritas Spetsialen Lager", 1 },
                    { 146, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(709), null, false, null, "Lomsko Amber Beer", 6 },
                    { 145, 5.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(690), null, false, null, "Lomsko Pivo Ubav Pustinyak", 7 },
                    { 144, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(670), null, false, null, "Vitoshko Lale Hoppy Weiss", 3 },
                    { 143, 4.7999999999999998, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(651), null, false, null, "Almus Lux", 1 },
                    { 142, 4.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(632), null, false, null, "Almus Lager", 1 },
                    { 141, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(613), null, false, null, "Vitoshko Lale", 1 },
                    { 140, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(593), null, false, null, "Almus Cherveno", 6 },
                    { 139, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(574), null, false, null, "Almus Tumno", 8 },
                    { 138, 5.7000000000000002, 22, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(554), null, false, null, "Kazan Artizan Ad Hoc IPA", 5 },
                    { 137, 6.5, 22, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(535), null, false, null, "Kazan Artizan Stout", 10 },
                    { 136, 5.5, 21, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(514), null, false, null, "Jägerhof Dunkel Weisse", 3 },
                    { 135, 7.0, 21, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(461), null, false, null, "Jägerhof Bock", 13 },
                    { 134, 5.2999999999999998, 21, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(442), null, false, null, "Jägerhof Ale", 6 },
                    { 133, 5.0, 21, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(423), null, false, null, "Jägerhof Dunkel", 8 },
                    { 132, 5.0, 21, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(403), null, false, null, "Jägerhof Weiss", 3 },
                    { 131, 4.9000000000000004, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(384), null, false, null, "Hills Weizen", 3 },
                    { 130, 5.2000000000000002, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(365), null, false, null, "Hills Single Stout", 10 },
                    { 147, 4.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(729), null, false, null, "Hmelo Lale", 2 },
                    { 148, 5.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(748), null, false, null, "Lomsko Pivo Blag Pustinyak", 3 },
                    { 149, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(768), null, false, null, "Lomsko Pivo Shopsko Pivo", 1 },
                    { 150, 7.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(787), null, false, null, "Lomsko Pivo Bash Pustinyak", 1 },
                    { 169, 6.5, 24, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1211), null, false, null, "Lucs Trevnensko", 8 },
                    { 168, 5.0, 24, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1192), null, false, null, "Lucs Cherry", 7 },
                    { 167, 5.0, 24, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1172), null, false, null, "Lucs Plum", 7 },
                    { 166, 3.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1153), null, false, null, "Optima Svetlo", 11 },
                    { 165, 3.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1133), null, false, null, "Dunavsko Lager", 1 },
                    { 164, 4.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1114), null, false, null, "Miziya Svetlo", 1 },
                    { 163, 3.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1095), null, false, null, "Tsarsko Lager", 1 },
                    { 162, 5.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1076), null, false, null, "Almus Special", 1 },
                    { 129, 6.2000000000000002, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(342), null, false, null, "Hills Smooth Bock", 13 },
                    { 161, 4.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1056), null, false, null, "Shopsko Svetlo", 1 },
                    { 159, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1017), null, false, null, "Lomsko Lux", 1 },
                    { 158, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(998), null, false, null, "Shipka", 1 },
                    { 157, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(979), null, false, null, "Lomsko Pivo Everyday Luxe", 1 },
                    { 156, 4.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(959), null, false, null, "Lomsko Pivo Everyday Lager", 1 },
                    { 155, 5.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(936), null, false, null, "Vitoshko Lale Tumno Pivo", 8 },
                    { 154, 4.5, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(865), null, false, null, "Vitoshko Lale Pale Ale", 4 },
                    { 153, 6.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(846), null, false, null, "Lomsko Porter", 9 },
                    { 151, 4.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(807), null, false, null, "Lomsko Pivo Pustinyak", 1 },
                    { 160, 4.0, 23, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1037), null, false, null, "Gredberg", 1 },
                    { 171, 5.0, 24, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(1250), null, false, null, "Lucs Svetlo", 2 },
                    { 128, 3.7999999999999998, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(323), null, false, null, "Hills Summer Blanche - Session Ale", 3 },
                    { 126, 5.0, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(285), null, false, null, "Hills Helles Rauch", 9 },
                    { 104, 5.0, 15, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9818), null, false, null, "Cohones Family Jewels", 4 },
                    { 103, 7.0, 15, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9799), null, false, null, "Cohones St. Out", 10 },
                    { 102, 7.5, 15, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9778), null, false, null, "Cohones Holy St. Out", 10 },
                    { 101, 4.2999999999999998, 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9729), null, false, null, "Can Supply Grussberg Pilsner", 11 },
                    { 100, 4.2999999999999998, 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9710), null, false, null, "Can Supply Odesos Svetlo Pivo", 1 },
                    { 99, 4.2999999999999998, 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9691), null, false, null, "Can Supply Odesos Markovo Pivo", 1 },
                    { 98, 4.7000000000000002, 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9671), null, false, null, "Can Supply Brexit Craft Beer", 4 },
                    { 97, 4.0, 14, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9651), null, false, null, "Can Supply Stobsko Pivo", 11 },
                    { 96, 4.7999999999999998, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9632), null, false, null, "Veritas Amber", 6 },
                    { 95, 5.2999999999999998, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9613), null, false, null, "Veritas Weizen", 3 },
                    { 94, 5.5, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9593), null, false, null, "Veritas Chervena", 7 },
                    { 93, 5.5, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9574), null, false, null, "Veritas Tumna", 8 },
                    { 92, 5.4000000000000004, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9554), null, false, null, "Veritas Green Lager", 11 },
                    { 91, 5.2000000000000002, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9535), null, false, null, "Veritas IPA", 5 },
                    { 90, 5.5, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9516), null, false, null, "Veritas Schwarz", 9 },
                    { 89, 4.9000000000000004, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9497), null, false, null, "Burgaska - Pivovarnata Summer Ale", 2 },
                    { 88, 6.2000000000000002, 13, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9478), null, false, null, "Veritas Single & Single", 2 },
                    { 105, 7.0, 16, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9837), null, false, null, "Dorst Zimen Bok", 8 },
                    { 106, 6.5999999999999996, 16, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9857), null, false, null, "Dorst Hippy Shake", 5 },
                    { 107, 6.0, 16, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9876), null, false, null, "Dorst Pink Future Mosaic", 7 },
                    { 108, 5.7999999999999998, 17, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9895), null, false, null, "Roustchouk Porter", 9 },
                    { 125, 5.0, 19, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(266), null, false, null, "Halbite Nashto Pivo", 4 },
                    { 152, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(827), null, false, null, "Lomsko Pivo Yak Pustinyak", 1 },
                    { 124, 4.5999999999999996, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(246), null, false, null, "Glarus London Porter", 9 },
                    { 123, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(227), null, false, null, "Glarus Holy Night", 10 },
                    { 122, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(203), null, false, null, "Glarus Signature Session IPA Mandarina Bavaria", 5 },
                    { 121, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(181), null, false, null, "Glarus Rhodopi Dream", 1 },
                    { 120, 4.7999999999999998, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(128), null, false, null, "Glarus Fruity & Hazy", 6 },
                    { 119, 4.2000000000000002, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(109), null, false, null, "Glarus Halo", 4 },
                    { 127, 4.7999999999999998, 20, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(304), null, false, null, "Hills Pils", 11 },
                    { 118, 4.2000000000000002, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(89), null, false, null, "Glarus Jester", 4 },
                    { 116, 4.2000000000000002, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(50), null, false, null, "Glarus Premium Ale", 2 },
                    { 115, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(30), null, false, null, "Glarus Saison", 3 },
                    { 114, 6.5, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(11), null, false, null, "Glarus Dubbel", 7 },
                    { 113, 4.5999999999999996, 18, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9991), null, false, null, "Glarus Special English Ale", 4 },
                    { 112, 6.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9972), null, false, null, "Glarus Black Sea IPA", 5 },
                    { 111, 5.0, 18, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9953), null, false, null, "Glarus Porter", 9 },
                    { 110, 6.2000000000000002, 17, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9933), null, false, null, "Dunav Radetzky", 4 },
                    { 109, 5.7000000000000002, 17, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(9914), null, false, null, "Dunav Sans Changement", 1 },
                    { 117, 5.5, 18, new DateTime(2020, 4, 25, 20, 19, 59, 511, DateTimeKind.Local).AddTicks(70), null, false, null, "Glarus Marzen", 3 },
                    { 1, 5.0, 1, new DateTime(2020, 4, 25, 20, 19, 59, 510, DateTimeKind.Local).AddTicks(7005), null, false, null, "Kaiser", 11 }
                });

            migrationBuilder.InsertData(
                table: "BeersDrank",
                columns: new[] { "UserId", "BeerId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 1 },
                    { 2, 1 },
                    { 1, 1 },
                    { 3, 4 },
                    { 1, 4 },
                    { 2, 4 },
                    { 1, 3 },
                    { 3, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Rating", "TargetBeerId", "Text" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(4571), null, false, null, "Na Gosho Review-to", 7, 3, "Evalata Pesho mnoo dobra bira" },
                    { 3, 3, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(4598), null, false, null, "Na Tosho Review-to", 8, 2, "Toz Pesho mnoo hubavi gi prai" },
                    { 1, 1, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(4359), null, false, null, "Na Pesho Review-to", 10, 1, "Mnoo dobra bira brat" },
                    { 4, 4, new DateTime(2020, 4, 25, 20, 19, 59, 512, DateTimeKind.Local).AddTicks(4620), null, false, null, "Kaiser nomer edno", 10, 1, "Bira ot butilka ne bqh pil do sq" }
                });

            migrationBuilder.InsertData(
                table: "WishlistBeers",
                columns: new[] { "UserId", "BeerId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 4 },
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_TypeId",
                table: "Beers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeersDrank_BeerId",
                table: "BeersDrank",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TargetBeerId",
                table: "Reviews",
                column: "TargetBeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistBeers_BeerId",
                table: "WishlistBeers",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeersDrank");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WishlistBeers");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
