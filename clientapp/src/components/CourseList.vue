<template>
  <div>
    <h1>CourseList</h1>
    <div>
      <div v-for="course in courses" :key="course.id">
        <router-link :to="`courses/${course.id}`">
          <img :src="course.img" />
          {{ course.name }}</router-link
        >
      </div>
    </div>
  </div>
</template>

<script>
import img1 from "../assets/img/asset30.png";
import img2 from "../assets/img/asset31.png";
import img3 from "../assets/img/asset32.png";

export default {
  data() {
    return {
      courses: [
        {
          id: 1,
          img: img1,
          name: "Basic",
        },
        {
          id: 2,
          img: img2,
          name: "Hard",
        },
        {
          id: 3,
          img: img3,
          name: "VeryHard",
        },
      ],
    };
  },
};
</script>
