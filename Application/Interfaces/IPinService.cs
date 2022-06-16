using Application.Dto;

namespace Application.Interfaces;
public interface IPinService
{
	IEnumerable<PinDto> GetAllPins();
	PinDto GetById(int id);
	PinDto AddNewPin(CreatePinDto newPin);
	public void UpdatePin(int id, UpdatePinDto newPin);
	public void DeletePin(int id);
}

