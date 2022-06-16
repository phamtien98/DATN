import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { SignIoComponent } from '../sign-io/sign-io.component';

@Component({
  selector: 'app-decrypt-io',
  templateUrl: './decrypt-io.component.html',
  styleUrls: ['./decrypt-io.component.css']
})
export class DecryptIoComponent implements OnInit {

  IOForm: FormGroup;
  dataModel: any;

  // ctor
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    public dialogRef: MatDialogRef<SignIoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  // onInit
  ngOnInit() {
    this.bindingConfigValidation();
    console.log(this.data);
  }

  // config Form use add or update
  bindingConfigAddOrUpdate() {

  }

  // config input validation form
  bindingConfigValidation() {

    this.IOForm = this.formBuilder.group({
      password: [""],
      pdfFile: [],
      certFile: []
    });
  }
  onFileChangeF1(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        pdfFile: file
      });
    }
  }
  onFileChangeF2(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        certFile: file
      });
    }
  }

  // on Submit
  public onSubmit() {

    let url = environment.url + "decrypt?password=" +  this.IOForm.get('password')?.value;

    const formData = new FormData();
    formData.append('pdfFile', this.IOForm.get('pdfFile')?.value);
    formData.append('certFile', this.IOForm.get('certFile')?.value);

    this.http.post(url,formData).subscribe((res:any) => {
      window.open(environment.urlServer + res.url, "_blank");
    });


  }

  // close sidebar
  public closeIOSidebar() {
  }

}
