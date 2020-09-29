<template>
  <div class="header">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div
        class="collapse navbar-collapse d-flex justify-content-between"
        id="navbarTogglerDemo01"
      >
        <div>
          <a class="navbar-brand ml-5" href="#">Xforum</a>
        </div>
        <div>
          <ul class="navbar-nav mt-2">
            <li class="nav-item mt-1">
              <svg
                width="1.5em"
                height="1.5em"
                viewBox="0 0 16 16"
                class="bi bi-pencil-square"
                fill="currentColor"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456l-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"
                />
                <path
                  fill-rule="evenodd"
                  d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"
                />
              </svg>
            </li>
            <li class="nav-item">
              <a class="nav-link ml-3" href="#">Login</a>
            </li>
            <li class="nav-item">
              <a class="nav-link ml-3" href="#">Register</a>
            </li>
            <input
              class="form-control ml-3"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button class="btn btn-outline-success ml-3" type="submit">
              Search
            </button>
          </ul>
        </div>
      </div>
    </nav>

    <vue-particles
      color="#dedede"
      :particleOpacity="0.7"
      :particlesNumber="80"
      shapeType="circle"
      :particleSize="4"
      linesColor="#dedede"
      :linesWidth="1"
      :lineLinked="true"
      :lineOpacity="0.4"
      :linesDistance="150"
      :moveSpeed="3"
      :hoverEffect="true"
      hoverMode="grab"
      :clickEffect="false"
      clickMode="push"
    >
    </vue-particles>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped></style>
