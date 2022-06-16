import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyIoComponent } from './verify-io.component';

describe('VerifyIoComponent', () => {
  let component: VerifyIoComponent;
  let fixture: ComponentFixture<VerifyIoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerifyIoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerifyIoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
