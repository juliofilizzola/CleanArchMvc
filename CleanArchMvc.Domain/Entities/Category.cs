using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category {
    public int Id { get; private set; }
    public string   Name  { get; private set; }
    public ICollection<Product> Products { get; private set; }

    public Category(string name) {
        ValidateDomainName(name);
        Name = name;
    }

    public Category(int id, string name) {
        ValidateDomainName(name);
        ValidateDomainId(id);

        Id   = id;
        Name = name;
    }

    public void Update(String name) {
        ValidateDomainName(name);
        Name = name;
    }

    private void ValidateDomainName(string name) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is Required");

        DomainExceptionValidation.When(name.Length < 3, "Invalid name.Name, minimum 2 characters");
    }

    private void ValidateDomainId(int id) {
        DomainExceptionValidation.When(id < 0, "Invalid id value");
    }
}