export class MemoryTimeCacheHelper {
  private static cache: { [key: string]: { value: any, expiry: number } } = {};

  static Get<T>(key: string): T | null {
    const item = MemoryTimeCacheHelper.cache[key];
    if (!item || item.expiry < Date.now()) {
      delete MemoryTimeCacheHelper.cache[key];
      return null;
    }
    return item.value as T;
  }

  static Set<T>(key: string, value: any, timeToLiveSeconds: number) {
    MemoryTimeCacheHelper.cache[key] = {value, expiry: Date.now() + timeToLiveSeconds * 1000};
  }

  static Delete(key: string): void {
    delete MemoryTimeCacheHelper.cache[key];
  }

  static Clear(): void {
    MemoryTimeCacheHelper.cache = {};
  }
}
