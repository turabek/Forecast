import { VuexModule, Module, Mutation, Action } from 'vuex-module-decorators'
import Forecast from '@/models/Forecast'
import { Inject } from 'inversify-props'
import IOfflineService from '@/services/IOfflineService'

@Module
export default class ForecastOfflineModule extends VuexModule {

    @Inject()
    private offlineService!: IOfflineService

    public offlineList = new Array<Forecast>()


    @Action({ rawError: true })
    public async fetchHistory(): Promise<void> {

        const newForecastList = await this.offlineService.GetAll()
        this.context.commit('setOfflineList', newForecastList)

    }

    @Action({ rawError: true })
    public async addToHistoryForecast(newForecast: Forecast): Promise<void> {

        this.offlineService.insertNew(newForecast);
        this.context.commit('setOffline', newForecast)

    }


    @Mutation
    setOfflineList(newForecastList: Array<Forecast>) {
        this.offlineList = newForecastList
    }


    @Mutation
    setOffline(newForecast: Forecast) {
        this.offlineList.push(newForecast)
    }



    get FORECAST_HISTORY(): Array<Forecast> {
        return this.offlineList
    }
}

