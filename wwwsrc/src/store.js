import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    keep: {},
    vaults: [],
    vault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      state.user = {}
      state.keep = {}
    },
    setKeep(state, keep) {
      state.keep = keep
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVault(state, vault) {
      state.vault = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, keeps) {
      state.vaultKeeps = keeps
    }
  },
  actions: {
    //#region -- Auth --
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "Home" })
      } catch (e) { console.warn(e.message) }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "Home" })
      } catch (e) { console.warn(e.message) }
    },
    async logout({ commit, dispatch }) {
      try {
        await AuthService.Logout()
        commit('resetState')
        router.push({ name: "Login" })
      } catch (e) { console.warn(e.message) }
    },
    //#endregion

    //#region -- Keeps --
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      } catch (err) { console.error(err) }
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/user')
        commit('setKeeps', res.data)
      } catch (err) { console.error(err) }
    },
    async createKeep({ commit, dispatch }, newKeep) {
      try {
        await api.post('keeps', newKeep)
        dispatch('getUserKeeps')
      } catch (err) { console.error(err) }
    },
    async updateKeep({ commit, dispatch }, keep) {
      try {
        await api.put('keeps/' + keep.id, keep)
        dispatch('getUserKeeps')
      } catch (err) { console.error(err) }
    },
    async updateKeepCounts({ commit, dispatch }, keep) {
      try {
        await api.put('keeps/' + keep.id + '/counts', keep)
        dispatch('getUserKeeps')
        dispatch('setActiveKeep', keep)
      } catch (err) { console.error(err) }
    },
    setActiveKeep({ commit, dispatch }, keep) {
      commit('setKeep', keep)
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        await api.delete('keeps/' + keepId)
        dispatch('getPublicKeeps')
        dispatch('getUserKeeps')
      } catch (err) { console.error(err) }
    },
    //#endregion

    //#region -- Vaults --
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
      } catch (err) { console.error(err) }
    },
    async getVaultById({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get('vaults/' + vaultId)
        commit('setVault', res.data)
      } catch (err) { console.error(err) }
    },
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get('vaults/' + vaultId + '/keeps')
        commit('setVaultKeeps', res.data)
      } catch (err) { console.error(err) }
    },
    async addKeepToVault({ commit, dispatch }, data) {
      try {
        await api.post('vaults/' + data.vaultId + "/keeps", data)
        dispatch('getVaultKeeps', data.vaultId)
      } catch (err) { console.error(err) }
    },
    async updateVault({ commit, dispatch }, vault) {
      try {
        await api.put('vaults/' + vault.id, vault)
        dispatch('getVaults')
      } catch (err) { console.error(err) }
    },
    async deleteVaultKeep({ commit, dispatch }, data) {
      try {
        await api.put('vaults/' + data.vaultId + "/keeps", data)
        dispatch('getVaultKeeps', data.vaultId)
      } catch (err) { console.error(err) }
    },
    setActiveVault({ commit, dispatch }, vault) {
      commit('setVault', vault)
    },
    async createVault({ commit, dispatch }, newVault) {
      try {
        let res = await api.post('vaults', newVault)
        commit('setVault', res.data)
        dispatch('getVaults')
      } catch (err) { console.error(err) }
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      try {
        await api.delete('vaults/' + vaultId)
        dispatch('getVaults')
      } catch (err) { console.error(err) }
    },

    //#endregion
  }
})
