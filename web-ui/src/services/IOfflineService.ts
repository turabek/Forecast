import Forecast from '@/models/Forecast';

export default interface IOfflineService{
    GetAll():Promise<Array<Forecast>>
    insertNew(newForecast:Forecast):any
}
