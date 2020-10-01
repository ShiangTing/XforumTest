<template>
  <div class="main-nav">
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <router-link class="title mx-5 my-2" to="home">Xforum</router-link>
      <!-- <b-navbar-brand href="#">Xforum</b-navbar-brand> -->

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input
              size="sm"
              class="mr-sm-2 mx-5"
              placeholder="Search"
            ></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" type="submit"
              >Search</b-button
            >
          </b-nav-form>
          <b-nav-item-dropdown class="mx-5 my-2">
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <em>Login</em>
            </template>
            <b-dropdown-item href="#">會員中心</b-dropdown-item>
            <b-dropdown-item href="#">註冊</b-dropdown-item>
            <b-dropdown-item href="#">登入</b-dropdown-item>
          </b-nav-item-dropdown>

          <!-- Using 'button-content' slot -->

          <b-nav-item href="#" class="mx-5 my-2">訪客</b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script></script>

<style lang="scss" scoped></style>
