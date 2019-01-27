import { Component } from '@angular/core';


import {environment} from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export clas AppComponent {
 // title = 'AngularCrudApp';
  NameEnv=environment.envName;
}
