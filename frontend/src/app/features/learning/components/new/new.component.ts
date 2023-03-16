import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css'],
})
export class NewComponent {
  form = new FormGroup({
    name: new FormControl(),
    description: new FormControl(),
    link: new FormControl(),
  });

  addIt() {
    // if the form is valid, dispatch an action
    console.log(this.form.valid);
    console.log(this.form.value);
  }
}
