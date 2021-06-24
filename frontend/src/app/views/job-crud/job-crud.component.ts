import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-job-crud',
  templateUrl: './job-crud.component.html',
  styleUrls: ['./job-crud.component.css']
})
export class JobCrudComponent {

  constructor(private router: Router) { }

  onClickNovo(): void {
    this.router.navigate(['/jobs/new']);
  }
}
