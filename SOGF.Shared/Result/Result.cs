using SOGF.Shared.Exception;

namespace SOGF.Shared.Result;

public record Result
{
    public bool isSuccess { get; }
    public Error? Error { get; }
    
    public bool? IsValidation { get; }
    public List<ValidationFailureResponse>? ValidationFailures { get; }


    protected Result(bool isSuccess,bool isValidation ,List<ValidationFailureResponse>? validationFailures)
    {
        this.isSuccess = isSuccess;
        IsValidation = isValidation;
        ValidationFailures = validationFailures;
    }
    
    protected Result(bool isSuccess, Error? error)
    {
        this.isSuccess = isSuccess;
        Error = error;
    }

    public static Result Succes() => new (true, false, []);

    public static Result Failure(Error error) =>
        new(false, error ?? throw new ArgumentNullException(nameof(Error)));

    public static Result ValidationFailure(List<ValidationFailureResponse> validationFailures) =>
        new(false,true, validationFailures);
    
    public static implicit operator Result(Error error) => 
        Failure(error);

    public static implicit operator Result(List<ValidationFailureResponse> validationFailures) =>
        ValidationFailure(validationFailures);
};
    public record Result<T> : Result
    {
        public T? Value { get; }
        private Result(T value) : base(true, null) => Value = value;
        
    
        private Result(Error error) : base(false, error)
        {
        }

        private Result(List<ValidationFailureResponse> validationFailures) : base(false, true, validationFailures)
        {
        }
        
        public static implicit operator Result<T>(T value) => new(value);

        public static implicit operator Result<T>(Error error) => new(error);
        
        public static implicit operator Result<T>(List<ValidationFailureResponse> validationFailures) => new(validationFailures);


    };
