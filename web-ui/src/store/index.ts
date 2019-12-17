import Vue from 'vue'
import Vuex from 'vuex'

// Modules
import ForecastModule from './modules/ForecastModule'
import ForecastOfflineModule from './modules/ForecastOfflineModule'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    ForecastModule,
    ForecastOfflineModule
  }
})
