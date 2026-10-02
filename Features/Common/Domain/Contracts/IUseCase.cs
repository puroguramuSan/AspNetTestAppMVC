namespace AspNetTestAppMVC.Features.Common.Domain.Contracts;

interface IUseCase<DTOInput, DTOOutput> 
  where DTOInput : class 
  where DTOOutput : class 
{
  public DTOOutput Exec();
}
