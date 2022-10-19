using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Kruchinin_28092022.Models;
using Kruchinin_28092022.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Variant2.ViewModels;

namespace Kruchinin_28092022.ViewModels
{
    public class Item
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Cost { get; set; }
        public string? Materials { get; set; }
        
        public Bitmap Image { get; set; }

        public Item(string title, string type, string articleNumber, decimal cost, string? materials, Bitmap image)
        {
            Title=title;
            Type=type;
            ArticleNumber=articleNumber;
            Cost=cost;
            Materials=materials;
            Image = image;
        }
    }

    public partial class MainWindowViewModel : ViewModelBase
    {
        public static MainWindow Page1 = null;
        public List<Item> Items;
        public MainWindowViewModel()
        {
            Items = GetDatabaseItems();
            Page1.ListItem.Items = Items;


        }
        private List<Item> GetDatabaseItems()
        {
            List<Item> items = new List<Item>();
            List<Product> products = new VosmerkaContext().Products
                .Include(p => p.ProductType)
                .ToList();

            foreach(Product product in products)
            {
                string? materials = GetMaterials(product.Id);
                Bitmap image = GetImage(product.Image);
                Item item = new Item(product.Title, product.ProductType.Title, product.ArticleNumber, product.MinCostForAgent, materials, image);

                items.Add(item);
            }

            return items;
        }

        private string? GetMaterials(int product_id)
        {
            StringBuilder sb = new StringBuilder();
            List<ProductMaterial> productMaterials = new VosmerkaContext().ProductMaterials
                .Include(m => m.Material)
                .Where(p => p.ProductId == product_id)
                .ToList();

            if (productMaterials.Count == 0)
                return null;

            sb.Append("Материалы: ");

            foreach (ProductMaterial pm in productMaterials)
                sb.Append($"{pm.Material.Title}, ");

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private Bitmap GetImage(string imageP)
        {
            string path = (imageP == null) ? "Assets/picture.png" : imageP;

            return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri($"avares://{Assembly.GetEntryAssembly().GetName().Name}/{path}")));

        }
    }
}