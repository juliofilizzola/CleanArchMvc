using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public class Product : Base {
    public string  Name        { get; private set; }
    public string  Description { get; private set; }
    public decimal Price       { get; private set; }
    public int     Stock       { get; private set; }
    public string  Image       { get; private set; }
    public int     CategoryId  { get; private set; }
    public Category      Category           { get; private set; }

    public Product(string name, string description, decimal price, string image, int stock, int categoryId) {
        ValidateDomain(name, description, stock, categoryId);
        Name        = name;
        Description = description;
        Price       = price;
        Stock       = stock;
        Image       = image;
    }

    public Product(int id, string name, string description, decimal price, string image, int stock, int categoryId) {
        ValidateDomain(name, description, stock, categoryId);
        ValidateIdDomain(id);
        Name        = name;
        Id          = id;
        Description = description;
        Price       = price;
        Stock       = stock;
        Image       = image;
    }

    private static void ValidateIdDomain(int id) {
        DomainExceptionValidation.When(id < 0, "Invalid id");
    }
    private static void ValidateDomain(string name, string description, int stock, int categoryId) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is Required");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description is Required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name.Name is Required");
        DomainExceptionValidation.When(description.Length < 3, "Invalid, Description is Required");
    }

}