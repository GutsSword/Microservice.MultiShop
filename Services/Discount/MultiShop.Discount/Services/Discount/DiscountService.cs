using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using System.Reflection.Metadata;

namespace MultiShop.Discount.Services.Discount
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parametres = new DynamicParameters();
            parametres.Add("@code", createCouponDto.Code);
            parametres.Add("@rate", createCouponDto.Rate);
            parametres.Add("@isActive", createCouponDto.IsActive);
            parametres.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("couponId", id);
            using(var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("@couponId", id);
            using (var connection = dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parametres);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("@code", updateCouponDto.Code);
            parametres.Add("@rate", updateCouponDto.Rate);
            parametres.Add("@isActive", updateCouponDto.IsActive);
            parametres.Add("@validDate", updateCouponDto.ValidDate);
            parametres.Add("@couponId", updateCouponDto.CouponId);

            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }
    }
}
