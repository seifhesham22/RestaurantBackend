using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DishSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Dishes",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "AverageRating", "Category", "CreateDateTime", "DeleteDate", "Description", "Image", "IsVegetarian", "ModifyDateTime", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00704d0a-1580-459d-8066-fea40d3d3bb6"), 0f, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SoGood", "Http//sdfjsdfjks;df", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seif", 0.0 },
                    { new Guid("05b857e1-245a-43e4-50a9-08dd60881c31"), 0f, 2, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7075), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Знаменитый тайский острый суп со сливками, куриным филе, шампиньонами, красным луком, помидором, перчиком Чили и кинзой. Подается с рисом. БЖУ на 100 г. Белки, г — 5,75 Жиры, г — 3,72 Углеводы, г — 14,76", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7075), "Том ям кай", 300.0 },
                    { new Guid("082a8b0a-e426-4332-50a5-08dd60881c31"), 0f, 1, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7055), "4 сыра", 360.0 },
                    { new Guid("1576460c-ace8-4207-418a-08dc375d5081"), 0f, 1, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Four Cheese: Mozzarella, Gouda, Feta, Dor Blue, creamy cheese sauce, and aromatic herbs", "https://avatars.mds.yandex.net/i?id=915e548c6f9167f66007e61edb6749d7_l-10870632-images-thumbs&n=13", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1701), "Four Cheese", 360.0 },
                    { new Guid("19f17528-cc34-47d1-50b2-08dd60881c31"), 0f, 3, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7128), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чизкейк Нью-Йорк - настоящая классика. Его основа - сочетание вкусов нежнейшего сливочного сыра и тонкой песочной корочки.", "https://mistertako.ru/uploads/products/120b46b1-5f32-11e8-8f7d-00155dd9fd01.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7128), "Чизкейк Нью-Йорк", 210.0 },
                    { new Guid("2135ede2-043c-4f8e-4194-08dc375d5081"), 0f, 4, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1794), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic milkshake with chocolate topping", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHhQ9CIw42wDRtzJEnQmeqPMYQ9TDNBEUziQ&s", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1794), "Chocolate Milkshake", 170.0 },
                    { new Guid("2626c344-492a-43e7-50a7-08dd60881c31"), 0f, 2, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7065), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сырный бульон с пшеничной лапшой, отварным куриным филе,помидором и сырными шариками. БЖУ на 100 г. Белки, г — 11,8 Жиры, г — 9,82 Углеводы, г — 22,69", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7065), "Рамен сырный", 300.0 },
                    { new Guid("2ed9c122-e260-49d4-418c-08dc375d5081"), 0f, 1, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smoked chicken breast, fresh mushrooms, pickled honey agarics, Mozzarella cheese, Gouda cheese, creamy garlic sauce, fresh herbs", "https://slicelife.imgix.net/677/photos/original/product-bellissimo-s-special-pizza-2444978.jpeg?auto=compress&auto=format", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1715), "Bellissimo", 400.0 },
                    { new Guid("32c20209-5477-4d8c-50a1-08dd60881c31"), 0f, 0, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7031), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами (шампиньоны, перец сладкий, лук красный) в томатном соусе с добавлением чесночно–имбирной заправки и петрушки. БЖУ на 100 г. Белки, г — 8,07 Жиры, г — 15,38 Углеводы, г — 23,22", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7031), "Wok болоньезе", 290.0 },
                    { new Guid("35286bf7-3459-44fe-4195-08dc375d5081"), 0f, 3, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange, banana, chocolate chips, cottage cheese, cheese flatbread. PFC per 100g: Protein, g — 5.86, Fat, g — 13.12, Carbohydrates, g — 44.05", "https://www.nourish-and-fete.com/wp-content/uploads/2022/04/orange-sweet-rolls-6-680x1020.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1803), "Sweet Roll with Orange and Banana", 250.0 },
                    { new Guid("369ea9d9-238c-48a9-50b1-08dd60881c31"), 0f, 3, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7124), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сырная лепешка, банан, киви, сливочный сыр, топинг клубничный", "https://mistertako.ru/uploads/products/9e7c8581-7a6f-11eb-850a-0050569dbef0.jpeg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7124), "Сладкий ролл с бананом и киви", 220.0 },
                    { new Guid("3ec56096-60e5-4ea6-50a0-08dd60881c31"), 0f, 0, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки. БЖУ на 100 г. Белки, г — 8,18 Жиры, г — 16,33 Углеводы, г — 20,62", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7021), "Wok а-ля Диаблo", 330.0 },
                    { new Guid("3f5f9309-6e31-41c3-50af-08dd60881c31"), 0f, 3, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7109), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05", "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7109), "Сладкий ролл с апельсином и бананом", 250.0 },
                    { new Guid("461ee2ed-dbf2-434a-418e-08dc375d5081"), 0f, 2, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramen broth with cream (chicken broth, garlic-ginger dressing, soy sauce) with wheat noodles, boiled chicken, Tamago omelet, and mushrooms. PFC per 100g: Protein, g — 8.13, Fat, g — 6.18, Carbohydrates, g — 8.08", "https://www.budgetbytes.com/wp-content/uploads/2019/09/Vegan-Creamy-Mushroom-Ramen-close.jpg", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1735), "Creamy Ramen with Chicken and Mushrooms", 260.0 },
                    { new Guid("49751e81-8c0e-480f-4189-08dc375d5081"), 0f, 0, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheat noodles, mushrooms, red onion, Tom Yum dressing (Tom Yum paste, Tom Kha paste, sugar, soy sauce), cream, soy sauce, tomato, chili pepper. PFC per 100g: Protein, g — 5.32, Fat, g — 14.89, Carbohydrates, g — 22.46", "https://blog.pokupon.ua/wp-content/uploads/2020/05/vok-doma.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1691), "Wok Tom Yum with Vegetables", 250.0 },
                    { new Guid("58941892-95d2-4fca-4190-08dc375d5081"), 0f, 4, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sea buckthorn, ginger, sugar", "https://24-ok.ru/image/lot/main/2023/01/13/04/a4bb3044c5d204aa4948ca56b115a4e4.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1759), "Sea Buckthorn Juice", 90.0 },
                    { new Guid("61b330b6-8b72-428b-4186-08dc375d5081"), 0f, 0, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheat noodles stir-fried in a wok with minced meat (beef/pork) and vegetables (mushrooms, sweet pepper, red onion) in tomato sauce, flavored with garlic-ginger dressing and garnished with parsley. PFC per 100g: Protein, g — 8.07, Fat, g — 15.38, Carbohydrates, g — 23.22", "https://media.leverans.ru/product_images_inactive/tomsk/mr-tako/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1667), "Wok Bolognese", 290.0 },
                    { new Guid("696981ab-aa05-4aaa-50ab-08dd60881c31"), 0f, 4, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Смородиновый морс", "https://mistertako.ru/uploads/products/120b46c1-5f32-11e8-8f7d-00155dd9fd01.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7089), "Морс cмородиновый", 90.0 },
                    { new Guid("6c3dcd8b-4f27-4874-4191-08dc375d5081"), 0f, 4, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1769), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blackcurrant juice", "https://avatars.mds.yandex.net/i?id=dfd98c18b1208fb86df895a7a5bc1783_l-5129388-images-thumbs&n=13", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1769), "Blackcurrant Juice", 90.0 },
                    { new Guid("7babaa47-180d-4bd7-50ad-08dd60881c31"), 0f, 4, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7099), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Классический молочный коктейль с клубничным топпингом", "https://mistertako.ru/uploads/products/120b46bd-5f32-11e8-8f7d-00155dd9fd01.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7099), "Коктейль клубничный", 170.0 },
                    { new Guid("8856ca0b-613f-48ee-4197-08dc375d5081"), 0f, 3, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheese flatbread, banana, kiwi, cream cheese, strawberry topping", "https://buy.am/media/image/0f/a5/3b/murakami-sweet-roll001.webp", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1818), "Sweet Roll with Banana and Kiwi", 220.0 },
                    { new Guid("8e0ec4df-52eb-44fd-4193-08dc375d5081"), 0f, 4, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1784), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic milkshake with strawberry topping", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSijQMCblLcadVZX1kzhdeVsxQnzo58nHDjJQ&s.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1784), "Strawberry Milkshake", 170.0 },
                    { new Guid("8e427982-31eb-4353-50aa-08dd60881c31"), 0f, 4, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7084), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Облепиха, имбирь, сахар", "https://mistertako.ru/uploads/products/5a7d58a5-879d-11eb-850a-0050569dbef0.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7084), "Морс облепиховый", 90.0 },
                    { new Guid("93493445-8194-4de2-4192-08dc375d5081"), 0f, 4, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1779), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic milkshake", "https://www.sharmispassions.com/wp-content/uploads/2016/04/VanillaMilkshake2.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1779), "Classic Milkshake", 140.0 },
                    { new Guid("a90116ce-e01a-4994-50ae-08dd60881c31"), 0f, 4, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Классический молочный коктейль с добавлением шоколадного топпинга", "https://mistertako.ru/uploads/products/120b46be-5f32-11e8-8f7d-00155dd9fd01.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7104), "Коктейль шоколадный", 170.0 },
                    { new Guid("ab8513f4-ed60-4534-418f-08dc375d5081"), 0f, 2, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Famous Thai spicy soup with cream, chicken fillet, mushrooms, red onion, tomato, chili pepper, and cilantro. Served with rice. PFC per 100g: Protein, g — 5.75, Fat, g — 3.72, Carbohydrates, g — 14.76", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRr5ngLC9pk6urmMRdTiRDYne3ytk1Q2ioSjg&s", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1740), "Tom Yum Gai", 300.0 },
                    { new Guid("b5ae41aa-67a8-4224-4196-08dc375d5081"), 0f, 3, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1808), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheese flatbread, banana, peanuts, cream cheese, chocolate chips, caramel topping", "https://healthyfamilyproject.com/wp-content/uploads/2017/10/web-Banana-Sushi-Rolls.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1808), "Sweet Roll with Peanuts and Banana", 210.0 },
                    { new Guid("b9496184-819a-47fe-50a4-08dd60881c31"), 0f, 0, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лапша пшеничная, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 5,32 Жиры, г - 14,89 Углеводы, г - 22,46", "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7050), "Wok том ям с овощами", 250.0 },
                    { new Guid("c426364c-f707-4e96-4185-08dc375d5081"), 0f, 0, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheat noodles stir-fried in a wok with pepperoni sausages, olives, sweet pepper, jalapeño peppers in tomato sauce, garnished with parsley. PFC per 100g: Protein, g — 8.18, Fat, g — 16.33, Carbohydrates, g — 20.62", "https://imgproxy.kuper.ru/imgproxy/size-500-500/czM6Ly9jb250ZW50LWltYWdlcy1wcm9kL3Byb2R1Y3RzLzI3MjM1MTU4L29yaWdpbmFsLzEvMjAyMy0xMC0xMlQyMyUzQTA3JTNBMDUuMzUxNTk3JTJCMDAlM0EwMC8yNzIzNTE1OF8xLmpwZw==.avif", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1652), "Wok à la Diablo", 330.0 },
                    { new Guid("c85b87b8-db43-4004-418b-08dc375d5081"), 0f, 1, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bacon, pickled cucumber, lingonberries, Mozzarella cheese, Gouda cheese, BBQ sauce", "https://images.gastronom.ru/4y_Q09IWsFuzepo5xbyYiEjnQjnXXaAGSepQqI8MLH8/pr:recipe-cover-image/g:ce/rs:auto:0:0:0/L2Ntcy9hbGwtaW1hZ2VzLzRmOGI1YjRiLTM0ZjMtNGNlNy04NzIwLWYyMGQ3NjVlMGE2Ni5qcGc.webp", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1706), "Party BBQ", 480.0 },
                    { new Guid("cbce5419-0097-4df0-4198-08dc375d5081"), 0f, 3, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York Cheesecake – a true classic. Its base is a combination of the delicate flavors of creamy cheese and a thin, crumbly biscuit crust", "https://www.onceuponachef.com/images/2017/12/cheesecake-760x882.jpg", true, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1828), "New York Cheesecake", 210.0 },
                    { new Guid("d077fc57-b474-446d-50a8-08dd60881c31"), 0f, 2, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7070), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бульон рамен со сливками (куриный бульон, чесночно-имбирная заправка, соевый соус) с пшеничной лапшой, отварной курицей, омлетом Томаго и шампиньонами. БЖУ на 100 г. Белки, г — 8,13 Жиры, г — 6,18 Углеводы, г — 8,08", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7070), "Сливочный рамен с курицей и шампиньонами", 260.0 },
                    { new Guid("d0c706ec-624b-42dc-50a3-08dd60881c31"), 0f, 0, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7045), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лапша пшеничная, креветки, кальмар, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 8,57 Жиры, г - 12,8 Углеводы, г - 18,8", "https://mistertako.ru/uploads/products/bacd88ca-54ed-11ed-8575-0050569dbef0.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7045), "Wok том ям с морепродуктам", 340.0 },
                    { new Guid("d73e3bf8-b488-4976-50ac-08dd60881c31"), 0f, 4, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7094), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Классический молочный коктейль", "https://mistertako.ru/uploads/products/120b46bc-5f32-11e8-8f7d-00155dd9fd01.jpg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7094), "Коктейль классический", 140.0 },
                    { new Guid("dc1f3446-5e24-485e-50a6-08dd60881c31"), 0f, 1, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Копченая куриная грудка, свежие шампиньоны, маринованные опята, сыр «Моцарелла», сыр «Гауда», сливочно-чесночный соус, свежая зелень.", "https://mistertako.ru/uploads/products/9ee8ed49-8327-11ec-8575-0050569dbef0.", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7060), "Белиссимо", 400.0 },
                    { new Guid("e054224e-65ef-4df3-4188-08dc375d5081"), 0f, 0, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1681), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheat noodles, shrimp, squid, mushrooms, red onion, Tom Yum dressing (Tom Yum paste, Tom Kha paste, sugar, soy sauce), cream, soy sauce, tomato, chili pepper. PFC per 100g: Protein, g — 8.57, Fat, g — 12.8, Carbohydrates, g — 18.8", "https://static.1000.menu/files/user-v2/3e/74/211/foto/f_14-10-2024-07-40-50.1728891651.jpg", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1681), "Wok Tom Yum with Seafood", 340.0 },
                    { new Guid("e18a4078-fad2-44a6-50b0-08dd60881c31"), 0f, 3, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7119), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сырная лепешка, банан, арахис, сливочный сыр, шоколадная крошка, топинг карамельный", "https://mistertako.ru/uploads/products/a4772f7a-7a6f-11eb-850a-0050569dbef0.jpeg", true, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7119), "Сладкий ролл с арахисом и бананом", 210.0 },
                    { new Guid("e8f66fdd-823a-4e6d-50a2-08dd60881c31"), 0f, 0, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7040), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 7,05 Жиры, г - 12,92 Углеводы, г - 18,65", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", false, new DateTime(2025, 3, 11, 10, 33, 6, 299, DateTimeKind.Unspecified).AddTicks(7040), "Wok том ям с курицей", 280.0 },
                    { new Guid("f1dd96aa-c73c-4279-418d-08dc375d5081"), 0f, 2, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheese broth with wheat noodles, boiled chicken fillet, tomato, and cheese balls. PFC per 100g: Protein, g — 11.8, Fat, g — 9.82, Carbohydrates, g — 22.69", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlcp7ywU4kvXbWLlQOHWzJlc4XY-NBrIqfog&s", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1725), "Cheesy Ramen", 300.0 },
                    { new Guid("fa5dc97a-6ffa-4476-4187-08dc375d5081"), 0f, 0, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1676), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheat noodles, chicken fillet, mushrooms, red onion, Tom Yum dressing (Tom Yum paste, Tom Kha paste, sugar, soy sauce), cream, soy sauce, tomato, chili pepper. PFC per 100g: Protein, g — 7.05, Fat, g — 12.92, Carbohydrates, g — 18.65", "https://nomadette.com/wp-content/uploads/2023/06/Tom-Yum-Stir-Fry.jpg", false, new DateTime(2024, 2, 27, 6, 28, 30, 319, DateTimeKind.Unspecified).AddTicks(1676), "Wok Tom Yum with Chicken", 280.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("00704d0a-1580-459d-8066-fea40d3d3bb6"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("05b857e1-245a-43e4-50a9-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("082a8b0a-e426-4332-50a5-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("1576460c-ace8-4207-418a-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("19f17528-cc34-47d1-50b2-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("2135ede2-043c-4f8e-4194-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("2626c344-492a-43e7-50a7-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("2ed9c122-e260-49d4-418c-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("32c20209-5477-4d8c-50a1-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("35286bf7-3459-44fe-4195-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("369ea9d9-238c-48a9-50b1-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("3ec56096-60e5-4ea6-50a0-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("3f5f9309-6e31-41c3-50af-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("461ee2ed-dbf2-434a-418e-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("49751e81-8c0e-480f-4189-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("58941892-95d2-4fca-4190-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("61b330b6-8b72-428b-4186-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("696981ab-aa05-4aaa-50ab-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("6c3dcd8b-4f27-4874-4191-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("7babaa47-180d-4bd7-50ad-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("8856ca0b-613f-48ee-4197-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("8e0ec4df-52eb-44fd-4193-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("8e427982-31eb-4353-50aa-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("93493445-8194-4de2-4192-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("a90116ce-e01a-4994-50ae-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("ab8513f4-ed60-4534-418f-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("b5ae41aa-67a8-4224-4196-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("b9496184-819a-47fe-50a4-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("c426364c-f707-4e96-4185-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("c85b87b8-db43-4004-418b-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("cbce5419-0097-4df0-4198-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d077fc57-b474-446d-50a8-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d0c706ec-624b-42dc-50a3-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d73e3bf8-b488-4976-50ac-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("dc1f3446-5e24-485e-50a6-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e054224e-65ef-4df3-4188-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e18a4078-fad2-44a6-50b0-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e8f66fdd-823a-4e6d-50a2-08dd60881c31"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("f1dd96aa-c73c-4279-418d-08dc375d5081"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("fa5dc97a-6ffa-4476-4187-08dc375d5081"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dishes",
                newName: "ID");
        }
    }
}
