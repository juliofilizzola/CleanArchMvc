using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public class Product : Base {
    public string  Name        { get; private set; }
    public string  Description { get; private set; }
    public decimal Price       { get; private set; }
    public int     Stock       { get; private set; }
    public string  Image       { get; private set; }
    public int     CategoryId  { get; set; }
    public Category      Category           { get; private set; }

    public Product(string name, string description, decimal price, string image, int stock, int categoryId, Category category) {
        ValidateDomain(name, description, stock, categoryId, price, image);
        Name        = name;
        Description = description;
        Price       = price;
        Stock       = stock;
        Category = category;
        Image       = image;
    }

    public Product(int id, string name, string description, decimal price, string image, int stock, int categoryId, Category category) {
        ValidateDomain(name, description, stock, categoryId, price, image);
        ValidateIdDomain(id);
        Name        = name;
        Id          = id;
        Description = description;
        Price       = price;
        Stock       = stock;
        Category = category;
        Image       = image;
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId) {
        ValidateDomain(name, description, stock, categoryId, price, image);
        Name        = name;
        Description = description;
        Price       = price;
        Stock       = stock;
        Image       = image;
        CategoryId  = categoryId;
    }

    private static void ValidateIdDomain(int id) {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
    }
    private static void ValidateDomain(string name, string description, int stock, int categoryId, decimal price, string image) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is Required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description is Required");
        DomainExceptionValidation.When(description.Length < 3, "Invalid, Description is Required");

        DomainExceptionValidation.When(stock <= 0, "Invalid stock value");
        DomainExceptionValidation.When(price <= 0, "Invalid price value");

        DomainExceptionValidation.When(image?.Length > 250 , "Invalid image name, too long, maximum 250 characters");
    }

}