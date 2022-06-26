using Application.Dto;

namespace Application.Interfaces;
public interface IPinService
{
	Task<IEnumerable<PinDto>> GetAllPins();
	Task<PinDto> GetById(int id);
	Task<PinDto> AddNewPin(CreatePinDto newPin);
	public Task UpdatePin(int id, UpdatePinDto newPin);
	public Task DeletePin(int id);
}

