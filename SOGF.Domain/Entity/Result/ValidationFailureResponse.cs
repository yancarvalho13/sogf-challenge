namespace Solution.Application.Dto;

public record ValidationFailureResponse(string? propertyName, string? errorMessage, string? attemptedValue);