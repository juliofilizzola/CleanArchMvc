using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1 {
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectValidState() {
        Action action = () => {
            var category = new Category(1, "Category Name ");
        };
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
}