import { container } from 'inversify-props'
import IForecastService from './services/IForecastService'
import ForecastService from './services/impl/ForecastService'
import IOfflineService from './services/IOfflineService'
import OfflineService from './services/impl/OfflineService'

export default function buildDependencyContainer (): void {
  container.addTransient<IForecastService>(ForecastService)
  container.addTransient<IOfflineService>(OfflineService)
}
