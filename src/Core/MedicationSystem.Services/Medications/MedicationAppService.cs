using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Entities;
using MedicationSystem.Services.Medications.Contracts;
using MedicationSystem.Services.Medications.Contracts.Dtos;
using MedicationSystem.Services.Medications.Exceptions;

namespace MedicationSystem.Services.Medications
{
    public class MedicationAppService : IMedicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicationRepository _medicationRepository;
        
        public MedicationAppService(
               IUnitOfWork unitOfWork,
               IMedicationRepository medicationRepository)
        {
            _unitOfWork = unitOfWork;
            _medicationRepository = medicationRepository;
        }
        
        public async Task AddAsync(AddMedicationDto dto)
        {
            PreventToAddMedicationWithZeroQuantity(dto.Quantity);
            
            var medication = new Medication
            {
                Code = dto.Code,
                Name = dto.Name,
                Type = dto.Type,
                Quantity = dto.Quantity
            };
            
            _medicationRepository.Add(medication);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<GetAllMedicationDto>> GetAllMedications()
        {
            return await _medicationRepository.GetAllMedications();
        }

        private void PreventToAddMedicationWithZeroQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new QuantityShouldBeGreaterThanZeroException();
            }
        }
    }
}