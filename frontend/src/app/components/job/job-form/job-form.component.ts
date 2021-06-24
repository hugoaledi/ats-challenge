import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PoDynamicFormField } from '@po-ui/ng-components';
import { JobModel } from 'src/app/models/job.model';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.css'],
  providers: [JobService]
})
export class JobFormComponent implements OnInit {

  job: JobModel = <JobModel>{};

  fields: Array<PoDynamicFormField> = [
    {
      property: 'title',
      divider: 'Dados da Vaga',
      required: true,
      gridColumns: 12,
      order: 1,
      label: 'Título'
    },
    {
      property: 'description',
      required: true,
      gridColumns: 12,
      order: 2,
      rows: 6,
      label: 'Descrição',
    },
  ];

  constructor(private router: Router, private route: ActivatedRoute, private jobService: JobService) { }

  private navigateGoBack(): void {
    this.router.navigate(['/jobs']);
  }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id') ?? '';

    if (id) {
      this.jobService.readById(id).subscribe(job => {
        if (!job) {
          this.navigateGoBack();
        } else {
          this.job = job;
        }
      },
        _ => this.navigateGoBack());
    }
  }

  onClickCancel(): void {
    this.navigateGoBack();
  }

  onClickSalvar(): void {
    if (this.route.snapshot.paramMap.get('id')) {
      this.jobService.update(this.job).subscribe(_ => this.navigateGoBack());
    } else {
      this.jobService.create(this.job).subscribe(_ => this.navigateGoBack());
    }
  }
}
