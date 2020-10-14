<template>
  <div>
    <Navbar />
    <div class="container py-5">
      <div class="row justify-content-center">
        <div class="col-9">
          <div class="card">
            <div class="card-body">
              <div class="row">
                <div class="col-6">
                  <h5 class="card-title">標題</h5>
                  <h6 class="card-subtitle mb-2 text-muted">作者: 132</h6>
                </div>
                <div class="col-6 d-flex justify-content-end align-items-center">
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="thumbs-up" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="thumbs-down" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="pen" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="trash" size="lg" />
                  </a>
                </div>
              </div>
              <hr>
              <div class="article-content">
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel, expedita unde. Minima
                  perspiciatis ut impedit harum illum accusantium tenetur iste temporibus quisquam earum id incidunt
                  dignissimos rerum modi, unde eveniet.</p>
                <img src="https://fakeimg.pl/300x300/123">
              </div>
            </div>
          </div>
          <div class="reply-group border p-3">
            <div class="reply-item">
              <div class="d-flex">
                <a class="user-img">
                  <font-awesome-icon icon="user" size="lg" />
                </a>
                <div class="reply-content">
                  <a class="replay-user">Mike</a>
                  <p>Lorem ipsum dolor sit amet</p>
                </div>
              </div>
            </div>
            <div class="reply-item">
              <div class="d-flex">
                <a class="user-img">
                  <font-awesome-icon icon="user" size="lg" />
                </a>
                <div class="reply-content">
                  <a class="replay-user">Mike</a>
                  <p>Lorem ipsum dolor sit amet</p>
                </div>
              </div>
            </div>
          </div>
          <div class="replay p-3 border">
            <div class="input-group">
              <a class="user-img">
                <font-awesome-icon icon="user" size="lg" />
              </a>
              <textarea class="form-control h-100" placeholder="留個言吧~"></textarea>
              <button class="btn btn-dark h-100">送出</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar"
export default {
  components: { Navbar },
  data () {
    return {

    };
  },
}
</script>
<style lang="scss" scoped>
  $border-color: 1px solid rgba(0, 0, 0, 0.125);
  .input-group {
    height: 35px;
  }
  p {
    margin: 0;
  }
  a.title-btn {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 40px;
    height: 40px;
    border: $border-color;
    margin-right: 5px;
    &:hover,
    &:active,
    &:focus {
      border: 1px solid red;
    }
  }
  textarea.form-control {
    resize: none;
    border: $border-color;
    &:active,
    &:focus {
      border: $border-color;
      outline: $border-color;
      box-shadow: 0px 0px transparent;
    }
  }
  .reply-item {
    padding: 10px;
    border-bottom: $border-color;
  }
  .user-img {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 40px;
    height: 40px;
    border-radius: 50%;
    border: 1px solid rgba(0, 0, 0, 0.125);
    margin-right: 10px;
  }
</style>