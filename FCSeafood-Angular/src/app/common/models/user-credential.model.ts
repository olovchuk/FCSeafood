export class UserCredentialModel {
  id: string = '';
  email: string = '';
  password: string = '';
  lastLoginDate: Date | null = null;
  lastPasswordChangedDate: Date | null = null;
}
