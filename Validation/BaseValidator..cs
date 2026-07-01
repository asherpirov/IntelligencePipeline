using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System;

namespace IntelligencePipeline.Validation;

abstract class BaseValidator : IValidator
{
 

    public ValidationResult Validate(Report report)
    {
        ValidationResult result = ValidateCommonFields(report);

        if (result.IsValid == false)
        {
            return result;
        }
        return ValidateSpecificFields(report);


    }
    
    protected ValidationResult ValidateCommonFields(Report report)
    {
        if (report.Timestamp < report.minDate)

        {
            return ValidationResult.Failure("Report timestamp cannot be before 2020-01-01.");
        }
        
        if (report.Timestamp > DateTime.Now)
        {
            return ValidationResult.Failure("Report timestamp cannot be in the future.");
        }

        if (report.Latitude < Report.MIN_LATITUDE || report.Latitude > Report.MAX_LATITUDE )
        {
            return ValidationResult.Failure("Report Latitude must be between 29.5000 - 33.5000");
        }

        if (report.Longitude < Report.MIN_LONGITUDE || report.Longitude > Report.MAX_LONGITUDE)
        {
            return ValidationResult.Failure("Report Longitude must be between 34.0000 - 36.0000");
        }

        if (report.Description.Length < Report.MIN_CHARS || report.Description.Length > Report.MAX_CHARS)
        {
            return ValidationResult.Failure("Report Description must be between 10-500 characters");
        }

        return ValidationResult.Success();
    }

    protected abstract ValidationResult ValidateSpecificFields(Report report);

}


