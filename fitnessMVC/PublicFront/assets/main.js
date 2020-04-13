// SLIDER SCRIPT START
var btLeft=document.getElementById("btnLeft");
var btRight=document.getElementById("btnRight")
var allsSlide=document.querySelectorAll(".slide-item")
var hazirkislide= 0;
btLeft.onclick=function(){
    sliderAll(hazirkislide-1)
}
btRight.onclick=function(){
    sliderAll(hazirkislide+1)
}

function sliderAll(say){
    allsSlide[hazirkislide].className="slide-item"
    hazirkislide = (say + allsSlide.length) % allsSlide.length;
    allsSlide[hazirkislide].className="slide-item active"
}

document.addEventListener("keyup", function(e){
    if(e.keyCode==39){
        sliderAll(hazirkislide+1)
    }else if(e.keyCode==37){
        sliderAll(hazirkislide-1)
    }
});

// SLIDER SCRIPT END



//BMI SCRIPT START

function calculateBmi() {
    var weight = document.bmiForm.weight.value
    var height = document.bmiForm.height.value
    if(weight > 0 && height > 0){	
    var finalBmi = weight/(height/100*height/100)
    document.bmiForm.bmi.value = finalBmi
    if(finalBmi < 18.5){
    document.bmiForm.meaning.value = "That you are too thin."
    }
    if(finalBmi > 18.5 && finalBmi < 25){
    document.bmiForm.meaning.value = "That you are healthy."
    }
    if(finalBmi > 25){
    document.bmiForm.meaning.value = "That you have overweight."
    }
    }
    else{
    alert("Please Fill in everything correctly")
    }
    }

    //BMI SCRIPT END