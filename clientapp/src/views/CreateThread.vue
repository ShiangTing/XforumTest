<template>
    <div>
        <Navbar />
        <b-row >
        <b-col></b-col>
        <b-col cols="8">
            <div class=" d-flex my-2  align-items-center">
            <label class="mr-3" for="Title">看板名稱:</label>
            <b-input
                v-model="titleContent"
                id="Title"
                class="mb-2 mr-sm-2 mb-sm-0 col-4"
                placeholder="請輸入文字"
                maxlength="5"
            ></b-input>
            <div class="text-danger small mt-1">
            {{ inputDataCheck.TitleErrorMsg }}
            </div>
            </div>
            <div class="d-block">
            <label class="mr-3" for="Textarea">申請說明:</label>
            <textarea 
                class="form-control"
                id="Textarea"
                rows="5"
                placeholder="請輸入文字"
                maxlength="500">
            </textarea>
            </div>

                <!-- :class="{ 'is-invalid': inputDataCheck.TitleError }"                 -->
                
                <!-- id="inline-form-input-name" -->
            <!-- <div class="text-danger small mt-1">
                {{ inputDataCheck.TitleErrorMsg }}
            </div> -->            
        </b-col>
        <b-col></b-col>
        </b-row>
    </div>
</template>

<script>
export default {
    components: {
        Navbar: () => import("@/components/common/Navbar"),
    },
    
    watch: {
        titleContent: {
        immediate: true,
        handler: function () {
            if (this.titleContent == "") {
            this.inputDataCheck.TitleError = true;
            this.inputDataCheck.TitleErrorMsg = "請輸入文字哦!";
            } else if (this.titleContent.length == 15) {
            this.inputDataCheck.TitleError = true;
            this.inputDataCheck.TitleErrorMsg = "最多只能15個字哦!";
            } else {
            this.inputDataCheck.TitleError = false;
            this.inputDataCheck.TitleErrorMsg = "";
            }
            this.checkAddVerify();
        },
        },
    }
}
</script>

<style lang="scss" scoped>
</style>