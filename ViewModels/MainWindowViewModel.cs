using Kruchinin_28092022.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kruchinin_28092022.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<ProductMaterial> productMaterials;
        public MainWindowViewModel()
        {
            productMaterials = new VosmerkaContext().ProductMaterials
                .Include(p => p.Product)
                .ThenInclude(pt => pt.ProductType)
                .ToList();
        }
        public List<ProductMaterial> ProductMaterials
        {
            get => productMaterials;
            set => productMaterials = value;
        }
    }
}