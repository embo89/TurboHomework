import { Controller } from '@hotwired/stimulus'

export default class extends Controller {

  static targets = ['username'];
  static classes = ['username'];

  connect() {
    this.styleUsername();
    //this.stylePassword();
  }

  usernameChange(eventObj) {
    this.styleUsername();
  }
  //passwordChange(eventObj) {
  //  this.stylePassword();
  //}

  styleUsername() {
    if (!this.usernameTarget.value)
      this.usernameTarget.classList.remove(...this.usernameClasses);
    else
      this.usernameTarget.classList.add(...this.usernameClasses);

  }

  //stylePassword() {
  //  if (!this.passwordTarget.Value)
  //    this.passwordTarget.classList.remove(...this.passwordstyleClasses);
  //  else
  //    this.passwordTarget.classList.remove(...this.passwordstyleClasses);
  //}
}