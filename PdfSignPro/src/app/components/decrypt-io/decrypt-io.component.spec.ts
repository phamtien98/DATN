import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DecryptIoComponent } from './decrypt-io.component';

describe('DecryptIoComponent', () => {
  let component: DecryptIoComponent;
  let fixture: ComponentFixture<DecryptIoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DecryptIoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DecryptIoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
