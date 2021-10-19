using Migrations.Framework48.Domain;
using System.Collections.Generic;

namespace Migrations.Framework48.ViewModels
{
    public class OverviewViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}