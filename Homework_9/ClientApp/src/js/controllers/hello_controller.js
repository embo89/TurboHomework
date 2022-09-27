import { Controller } from '@hotwired/stimulus';

export default class extends Controller {

  static targets = ['nameuser'];
  static values = {
    counter: Number
  };
  static classes = ['empty'];

  connect() {
    this.sayHi('hello');
    this.styleNameuser();
  }

  nameuserChange(eventObj) {
    this.styleNameuser();
  }

  styleNameuser() {
    if (!this.nameuserTarget.value)
      this.nameuserTarget.classList.add(...this.emptyClasses);
    else
      this.nameuserTarget.classList.remove(...this.emptyClasses);
  }


  sayHi(controllerName) {
    console.log(`Hello from the '${controllerName}' controller.`, this.element);
  }

  greet(eventObj) {
    console.log('Hello from element:', this.element, eventObj.target);

    if (this.hasMessageTarget)
      console.log(`Greetings ${this.messageTarget.value ? this.messageTarget.value : 'no one'}!`);

    this.counterValue++;
  }



  counterValueChanged(newValue, oldValue) {
    console.log(`Greeting count is ${newValue}`);
  }

  //if (this.hasNameuserTarget) {

  //  console.log(`Greetings ${this.nameuserTarget.value ? this.nameuserTarget.value : 'no one'}!`);

  //}

}