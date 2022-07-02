import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-verify-io',
  templateUrl: './verify-io.component.html',
  styleUrls: ['./verify-io.component.css']
})
export class VerifyIoComponent implements OnInit {

  IOForm: FormGroup;
  dataModel: any;
  content: any;
  // ctor
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    public dialogRef: MatDialogRef<VerifyIoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public snackBar: MatSnackBar,
  ) { }

  // onInit
  ngOnInit() {
    this.bindingConfigValidation();

    this.content = this.data.model.split("\r\n");
    console.log(this.content);
  }

  // config input validation form
  bindingConfigValidation() {

    this.IOForm = this.formBuilder.group({
      formFile: [],
    });
  }
  onFileChange(event: any) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        formFile: file
      });
    }
  }

  // on Submit
  public onSubmit() {

    let url = environment.url + "VerifySignature";

    const formData = new FormData();
    formData.append('formFile', this.IOForm.get('formFile')?.value);

    this.http.post(url, formData).subscribe((res: any) => {
      this.snackBar.open(res.message, '', {
        duration: 500000,
      });

    });


  }

  // close sidebar
  public closeIOSidebar() {
  }

}
