import { Vue } from 'vue-property-decorator'
import App from './App.vue'
import store from './store'
import buildDependencyContainer from './app.container'
import moment from 'moment'
import VueLocalStorage from 'vue-localstorage'

class AppBootstrap {
  constructor() {
    this.loadDependencyContainer()
    this.loadVueApp()
  }

  private loadDependencyContainer(): void {
    buildDependencyContainer()
  }

  private loadVueApp(): void {
    Vue.config.productionTip = false
    Vue.filter('formatDate', function (value: Date) {
      if (value) {
        return moment(String(value)).format('LL')
      }
    }
    );

    Vue.use(VueLocalStorage)

    Vue.config.errorHandler = function(err, vm, info) {
      console.log(`Error: ${err.toString()}\nInfo: ${info}`);
      alert('Oops, something went wrong.');
    }
    
    new Vue({
      store,
      render: h => h(App)
    }).$mount('#app')
  }
}

// eslint-disable-next-line no-new
new AppBootstrap()
