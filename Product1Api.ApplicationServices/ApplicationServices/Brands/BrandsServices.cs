using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Brands;
using Product1Api.Common.Models.Brands;
using Product1Api.Common.Repository.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Brands
{
    public class BrandsServices : IBrandsServices                   
    {
        private readonly IBrandsRepository _brandRepository;

        public BrandsServices(IBrandsRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public List<Brands1> getbrands()
        {
            return _brandRepository.GetBrands();
        }
        public async Task createbrand([FromForm] BrandsDto brandsDto)
        {
            _brandRepository.CreateBrand(brandsDto);
        }
        public async Task updatebrand(int id, [FromForm] BrandsDto brandsDto)
        {
            _brandRepository.UpdateBrand(id, brandsDto);

        }
        public void deletebrand(int id)
        {
            _brandRepository.DeleteBrand(id);
        }
        public Brands1 idbrand(int id)
        {
            return _brandRepository.IdBrand(id);
        }

    }
}
