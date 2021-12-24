import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const beforeEnter = (to, from, next) => {
  const token = localStorage.getItem('token');
  if (token) {
    next()
    return true;
  }
  next({ path: '/login'});
  return false;
}

const routes = [
  {
    path: '/',
    name: 'Kanban',
    component: () => import('../views/Kanban.vue'),
    beforeEnter,
  },
  {
    path: '/calendar',
    name: 'Calendar',
    component: () => import('../views/Calendar.vue'),
    beforeEnter
  },
  {
    path: '/analytics',
    name: 'Analytics',
    component: () => import('../views/Analytics.vue'),
    beforeEnter
  },
  {
    path: '/settings',
    name: 'Settings',
    component: () => import('../views/Settings.vue'),
    beforeEnter
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../views/Auth/Login.vue')
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('../views/Auth/Register.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
