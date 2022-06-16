import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncryptIoComponent } from './encrypt-io.component';

describe('EncryptIoComponent', () => {
  let component: EncryptIoComponent;
  let fixture: ComponentFixture<EncryptIoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncryptIoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EncryptIoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
