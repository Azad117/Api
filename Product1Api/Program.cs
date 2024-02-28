using Product1Api.Repositories.Products;
using Product1Api.Common.ApplicationServices;
using Product1Api.Common.Repository;
using Product1Api.ApplicationServices.ApplicationServices.Products;
using Product1Api.Common.Repository.Brands;
using Product1Api.Repositories.Brands;
using Product1Api.ApplicationServices.ApplicationServices.Brands;
using Product1Api.Common.ApplicationServices.Brands;
using Product1Api.Common.Repository.Category;
using Product1Api.Common.ApplicationServices.Category;
using Product1Api.ApplicationServices.ApplicationServices.Category;
using Product1Api.Repositories.Category;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.ApplicationServices.ApplicationServices.Attributes;
using Product1Api.Common.Repository.Attributes;
using Product1Api.Repositories.Attributes;
using Product1Api.Common.ApplicationServices.Associations;
using Product1Api.Common.Repository.Associations;
using Product1Api.Repositories.Associations;
using Product1Api.ApplicationServices.ApplicationServices.Associations;
using Product1Api.Common.ApplicationServices.Customer;
using Product1Api.Common.Repository.Customer;
using Product1Api.Repositories.Customer;
using Product1Api.ApplicationServices.ApplicationServices.Customer;
using Product1Api.Common.Repository.User;
using Product1Api.ApplicationServices.ApplicationServices.User;
using Product1Api.Common.ApplicationServices.User;
using Product1Api.Repositories.User;
using Product1Api.Common.ApplicationServices.Orders;
using Product1Api.ApplicationServices.ApplicationServices.Orders;
using Product1Api.Common.Repository.Orders;
using Product1Api.Repositories.Orders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDb,Db>();
            // Configure repositories and services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<IBrandsServices, BrandsServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAttributeTabSer, AttributeTabSer>();
builder.Services.AddScoped<IAttributeGroupSer, AttributeGroupSer>();
builder.Services.AddScoped<IAttributesSer , AttributesSer>();
builder.Services.AddScoped<IAttributesRep, AttributesRep>();
builder.Services.AddScoped<IAttributeTabRep , AttributeTabRep>();
builder.Services.AddScoped<IAttributeGroupRep , AttributeGroupRep>();
builder.Services.AddScoped<IAssociatedProductsSer, AssociatedProductsSer>();
builder.Services.AddScoped<IAssociatedProductsRep, AssociatedProductsRep>();
builder.Services.AddScoped<IAssociationsSer, AssociationsSer>();
builder.Services.AddScoped<IAssociationsRep, AssociationsRep>();
builder.Services.AddScoped<ICustomerRep, CustomerRep>();
builder.Services.AddScoped<ICustomerSer, CustomerSer>();
builder.Services.AddScoped<IUserRep, UserRep>();
builder.Services.AddScoped<IUserSer, UserSer>();
builder.Services.AddScoped<IOrdersSer, OrdersSer>();
builder.Services.AddScoped<IOrdersRep, OrdersRep>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
